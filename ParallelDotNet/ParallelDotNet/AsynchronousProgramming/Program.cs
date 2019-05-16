﻿using System;

namespace AsynchronousProgramming
{
    /// <summary>
    /// Await DOES NOT perform a physical
    ///
    /// </summary>

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");
            AsyncAwaitTest aat = new AsyncAwaitTest();
            aat.ConsumeAsync();
            Console.WriteLine("after Consume Async without await Program");
            Console.WriteLine("Ending Program");
        }
    }
}