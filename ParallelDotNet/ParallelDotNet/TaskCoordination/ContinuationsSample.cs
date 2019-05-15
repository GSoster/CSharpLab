using System;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class ContinuationsSample
    {
        public void SimpleContinuationSample()
        {
            System.Console.WriteLine("Continuation");
            var task1 = Task.Factory.StartNew(() => Console.WriteLine($"boiling water"));
            var task2 = task1.ContinueWith(task =>
            {
                Console.WriteLine($"Completed task {task.Id}. Pour water into cup");
            });

            Task.Factory.StartNew(() => Console.WriteLine("Task Before task.Wait"));
            Console.WriteLine("cw before wait");

            task2.Wait();
            Console.WriteLine("cw after wait");
        }

        public void ContinueWhenAllSample()
        {
            System.Console.WriteLine("Continue When All");
            var task1 = Task.Factory.StartNew(() => "task 1");//task doest do anything, just returns a value
            var task2 = Task.Factory.StartNew(() => "task 2");//task doest do anything, just returns a value

            var task3 = Task.Factory.ContinueWhenAll(new[] { task1, task2 }, tasks =>
             {
                 Console.WriteLine("Tasks have been completed");
                 foreach (var item in tasks)
                 {
                     Console.WriteLine($" - {item.Result}");
                 }
                 Console.WriteLine("All tasks done");
             });

            task3.Wait();
        }

        public void ContinueWhenAny()
        {
            System.Console.WriteLine("Continue When Any");
            var task1 = Task.Factory.StartNew(() => "task 1");//task doest do anything, just returns a value
            var task2 = Task.Factory.StartNew(() => "task 2");//task doest do anything, just returns a value

            var task3 = Task.Factory.ContinueWhenAny(new[] { task1, task2 }, task =>
            {
                Console.WriteLine("Task completed");

                Console.WriteLine($" - {task.Result}");

                Console.WriteLine("All tasks done");
            });

            task3.Wait();
        }
    }
}