using System;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        //unit of work (want to execute in separated Task)
        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }

        public static int TextLength(object o)
        {
            Console.WriteLine($"\n Task with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }

        private static void Main(string[] args)
        {
            //Unit of work: Write
            //StartNew does two things at the same time: Cretes a task AND starts it.
            //Task.Factory.StartNew(() => Write('.'));
            // new Task only creates a new Task but doesn't start it yet
            //var t = new Task(() => Write('?'));
            //t.Start();

            //Getting Results of a task
            // unit of work: TextLenght
            //getting the result of a task is blocking
            string text1 = "Testing", text2 = "this";
            var t1 = new Task<int>(TextLength, text1);
            t1.Start();
            Task<int> t2 = Task.Factory.StartNew<int>(TextLength, text2);
            Console.WriteLine($"Length of '{text1}' is {t1.Result}");
            Console.WriteLine($"Length of '{text2}' is {t2.Result}");

            Console.WriteLine("Main program done.");
            Console.ReadKey();
        }
    }
}