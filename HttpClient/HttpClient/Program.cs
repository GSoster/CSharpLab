using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientAPIConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("...");
            HttpClientHandler handler = new HttpClientHandler();            
            WebProxy proxy = new WebProxy("http://proxy.us.dell.com:80");
            proxy.UseDefaultCredentials = true;            
            handler.Proxy = proxy;
            HttpClient client = new HttpClient(handler);
            string uri = "https://jsonplaceholder.typicode.com/posts";
            var response = client.GetStringAsync(uri).GetAwaiter().GetResult();
            Console.WriteLine(response);
            
        }
        
    }
}
