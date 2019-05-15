using System;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class ParallelInvokeForForEach
    {
        /// <summary>
        /// Parallel.Invoke basically takes your functions that you want to run
        /// and run them concurrently
        /// </summary>
        public void ParallelInvoke()
        {
            Console.WriteLine("Parallel Invoke");
            var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            Parallel.Invoke(a, b, c);
        }

        public void ParallelForLoop()
        {
            Console.WriteLine("Parallel For");
            //upper bound of Parallel.For is exclusive
            Parallel.For(1, 11, i =>
            {
                Console.WriteLine($"{i} \t");
            });
        }

        public void ParallelForEach()
        {
            string[] words = { "oh", "what", "word", "night" };
            Parallel.ForEach(words, word =>
            {
                Console.WriteLine($"{word} has length {word.Length} (Task {Task.CurrentId})");
            });
        }
    }
}