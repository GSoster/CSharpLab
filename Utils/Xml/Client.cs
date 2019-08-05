using System;

namespace Xml
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}