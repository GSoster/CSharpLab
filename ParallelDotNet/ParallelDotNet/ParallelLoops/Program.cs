using System;

namespace ParallelLoops
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ParallelInvokeForForEach parallel = new ParallelInvokeForForEach();
            parallel.ParallelInvoke();
            Console.WriteLine("-------------");
            parallel.ParallelForLoop();
            Console.WriteLine("-------------");
            parallel.ParallelForEach();
        }
    }
}