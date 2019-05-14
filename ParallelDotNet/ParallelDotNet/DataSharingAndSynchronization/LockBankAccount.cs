namespace DataSharingAndSynchronization
{
    public class LockBankAccount
    {
        public int Balance { get; set; }
        public object padlock { get; set; } = new object();

        public void Deposit(int amount)
        {
            lock (padlock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }
    }
}