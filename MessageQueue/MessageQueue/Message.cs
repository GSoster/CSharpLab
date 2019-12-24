using System.Text;

namespace MessageQueue
{
    public class Message
    {
        public readonly byte[] Data;

        public Message()
        {
        }

        public Message(byte[] data)
        {
            Data = data;
        }

        public Message(string type, byte[] data)
        {
            Subject = type;
            Data = data;
        }

        public string Subject { get; set; }
        public string DataAsString => Encoding.UTF8.GetString(Data);
    }
}