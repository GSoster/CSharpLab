using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    internal class Program
    {
        private static ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();

        //Blocking Collections!!
        private static BlockingCollection<int> messages = new BlockingCollection<int>(new ConcurrentBag<int>(), 10);

        private static CancellationTokenSource cts = new CancellationTokenSource();

        private static Random random = new Random();

        public static void AddParis()
        {
            var success = capitals.TryAdd("France", "Paris");
            string whoTriedToAdd = Task.CurrentId.HasValue ? ("Task" + Task.CurrentId) : "Main Thread";
            Console.WriteLine($"{whoTriedToAdd} {(success ? "Added" : "did not add")} the element");
        }

        private static void RunConsumer()
        {
            foreach (var item in messages.GetConsumingEnumerable())
            {
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine($"-{item}\t");
                Thread.Sleep(random.Next(1000));
            }
        }

        private static void RunProducer()
        {
            while (true)
            {
                cts.Token.ThrowIfCancellationRequested();
                int i = random.Next(1000);
                messages.Add(i);
                Console.WriteLine($"+{i}\t");
                Thread.Sleep(random.Next(1000));
            }
        }

        private static void ProduceAndConsume()
        {
            var producer = Task.Factory.StartNew(RunProducer);
            var consumer = Task.Factory.StartNew(RunConsumer);

            try
            {
                Task.WaitAll(new[] { producer, consumer }, cts.Token);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => true);
            }
        }

        private static void Main(string[] args)
        {
            Task.Factory.StartNew(AddParis).Wait();
            AddParis();

            capitals["Russia"] = "Leningrad";
            //capitals["Russia"] = "Moscow"; //updates silently, without raising exception
            capitals.AddOrUpdate("Russia", "Moscow", (key, oldValue) => oldValue + " updated to Moscow");
            Console.WriteLine(capitals["Russia"]);

            //get
            capitals["Sweden"] = "uppsala";
            var capOfSweden = capitals.GetOrAdd("Sweden", "Stockhold"); //if it doesnt exist, add stockhold..

            //BlockingCollections!
            Task.Factory.StartNew(ProduceAndConsume, cts.Token);
            Console.ReadKey();
            cts.Cancel();
        }
    }
}