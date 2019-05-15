using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class ChildTasksSample
    {
        public void SimpleChildTaskSample()
        {
            var parent = new Task(() =>
            {
                //by default child tasks are detached from their parents. it means
                // that the parent task will not wait it finish.
                // if we wait the parent task it (the parent) can complete without the child has completed
                // to attach the child task to the parent we MUST use a parameter on the child task creation:
                // TaskCreationOptions.AttachedToParent
                var child = new Task(() =>
                {
                    Console.WriteLine("Child task starting");
                    Thread.Sleep(3000);
                    Console.WriteLine("Child task finishing");
                }, TaskCreationOptions.AttachedToParent);

                //Continuation WITH child tasks:
                // Only executes if the child task run to completion
                var completionHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Task {t.Id} stat is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                // Only executes if the child task fails
                var failHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Oops...Task {t.Id} stat is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

                child.Start();
            });
            parent.Start();

            try
            {
                parent.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => true);
            }
        }
    }
}