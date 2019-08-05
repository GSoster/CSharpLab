using System;

namespace Xml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var xml = new XmlWriter();
            var client = new Client()
            {
                FirsName = "Guilherme",
                LastName = "Santos",
                Rating = 2300
            };
            var doc = xml.MapClassToXmlDocPropAsElement(client);
            Console.WriteLine(doc);

            var doc2 = xml.MapClassToXmlDocPropAsElement(client, true);
            Console.WriteLine(doc2);
            Console.WriteLine("\t ############## \n");

            var purchase = new Purchase()
            {
                OrderNumber = "order number demo",
                SellerId = "Sell"
            };
            Console.WriteLine(purchase);
            Console.WriteLine(xml.MapClassToXmlDocPropAsElement(purchase));
        }
    }
}