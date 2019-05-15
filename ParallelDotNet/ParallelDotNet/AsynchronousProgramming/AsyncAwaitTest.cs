using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    public class AsyncAwaitTest
    {
        public int Calculate()
        {
            return 5;
        }

        public Task<int> CalculateAsync()
        {
            return Task.Factory.StartNew(() => 5);
        }

        public async Task ConsumeAsync()
        {
            System.Console.WriteLine("Starting...");
            var myNumber = await CalculateAsync();
            System.Console.WriteLine($"Inside Consume, after await, result is: {myNumber}");
        }
    }
}