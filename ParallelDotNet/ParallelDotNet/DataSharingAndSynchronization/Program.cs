using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataSharingAndSynchronization
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Bank Account versions
            var lockBancoAccount = new LockBankAccount();
            var interlockedBankAccount = new InterlockedBankAccount();

            //SpinLock
            var bankAccount = new BankAccount();
            SpinLock sl = new SpinLock();

            // MUTEX
            var baMutex = new BankAccount();
            Mutex mutex = new Mutex();

            var tasks = new List<Task>();

            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    lockBancoAccount.Deposit(100);
                    interlockedBankAccount.Deposit(100);

                    //'Trying' to lock a Simple Banck account
                    var lockTaken = false;
                    try
                    {
                        sl.Enter(ref lockTaken);
                        bankAccount.Deposit(100);
                    }
                    finally
                    {
                        if (lockTaken)
                            sl.Exit();
                    }

                    //Mutex Lock
                    bool haveLock = mutex.WaitOne();
                    try
                    {
                        baMutex.Deposit(100);
                    }
                    finally
                    {
                        if (haveLock)
                            mutex.ReleaseMutex();
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    lockBancoAccount.Withdraw(100);
                    interlockedBankAccount.Withdraw(100);

                    //'Trying' to lock a Simple Banck account
                    var lockTaken = false;
                    try
                    {
                        sl.Enter(ref lockTaken);
                        bankAccount.Withdraw(100);
                    }
                    finally
                    {
                        if (lockTaken)
                            sl.Exit();
                    }

                    //Mutex Lock
                    bool haveLock = mutex.WaitOne();
                    try
                    {
                        baMutex.Withdraw(100);
                    }
                    finally
                    {
                        if (haveLock)
                            mutex.ReleaseMutex();
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final Balance Lock Bank Account: {lockBancoAccount.Balance}");
            Console.WriteLine($"Final Balance InterlockedBank Account: {interlockedBankAccount.Balance}");
            Console.WriteLine($"Final Balance Bank Account (Spin Lock): {bankAccount.Balance}");
            Console.WriteLine($"Final Balance Bank Account (Mutex): {baMutex.Balance}");
        }
    }
}