namespace DataSharingAndSynchronization
{
    public class BankAccount
    {
        public int Balance { get; set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
    }
}