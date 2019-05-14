using System.Threading;

namespace DataSharingAndSynchronization
{
    public class InterlockedBankAccount
    {
        private int balance;
        public int Balance { get { return balance; } set { balance = value; } }

        public void Deposit(int amount)
        {
            Interlocked.Add(ref balance, amount);
        }

        public void Withdraw(int amount)
        {
            Interlocked.Add(ref balance, -amount);
        }
    }
}