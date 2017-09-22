using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public abstract class Animal
        {
            public string Name { get; protected set; }
            public abstract void SetName(string value);
        }

        public class Cat : Animal
        {
            public override void SetName(string value)
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value");

                if (value == this.Name)
                    throw new ArgumentException("value is duplicate");

                this.Name = value;
            }

        }

        public class Dog : Animal
        {
            public override void SetName(string value)
            {
                //code contract - validade input
                Contract.Requires(!string.IsNullOrWhiteSpace("value is empty"));
                this.Name = value;
            }

            public string GetName()
            {
                //validade output
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
                return this.Name;
            }
        }
    }
}
