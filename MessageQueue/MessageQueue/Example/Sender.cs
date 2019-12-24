using System.Text;

namespace MessageQueue.Example
{
    public class Sender
    {
        private readonly MessageQueue messageQueue;

        public Sender(MessageQueue messageQueue)
        {
            this.messageQueue = messageQueue;
        }

        public void SendMessage(string messageData)
        {
            var message = new Message("This message was sent by SENDER", Encoding.UTF8.GetBytes(messageData));
            this.messageQueue.Add(message);
        }
    }
}