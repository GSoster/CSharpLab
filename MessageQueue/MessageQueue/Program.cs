using MessageQueue.Example;
using System.Threading.Tasks;

namespace MessageQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sender = new Sender(MessageQueue.Instance);

            Parallel.For(0, 300, i => sender.SendMessage($"my message number [{i}]"));

            while (MessageQueue.Instance.MessageQueuedCount > 0)
            {
                System.Console.WriteLine(MessageQueue.Instance.Read().DataAsString);
            }
            System.Console.WriteLine("Messaeg queue is empty");
        }
    }
}