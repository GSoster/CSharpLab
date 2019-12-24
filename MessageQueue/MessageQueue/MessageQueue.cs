using System.Collections.Generic;

namespace MessageQueue
{
    public sealed class MessageQueue
    {
        private static MessageQueue instance;

        private readonly List<Message> messages = new List<Message>();

        public static MessageQueue Instance
        {
            get
            {
                return instance ?? (instance = new MessageQueue());
            }
        }

        public int MessageQueuedCount => this.messages.Count;

        public void Add(Message message)
        {
            this.messages.Add(message);
        }

        public Message Read()
        {
            if (this.messages.Count <= 0)
                return null;
            var message = this.messages[0];
            messages.RemoveAt(0);
            return message;
        }
    }
}