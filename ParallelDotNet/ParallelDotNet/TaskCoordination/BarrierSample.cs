using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class BarrierSample
    {
        /// Barriers allow us to separate tasks that must be run together
        /// before other tasks that also need to be run but have need in the previous
        /// Lets say we want to make tea. We can't put the water on the cup before we have finished finding
        /// a cup.
        /// We also can't put sugar on the cup without the water.
        /// So we need a BARRIER that says that part of the task can only be executed after some pre-defined
        /// stage has been reached.

        private Barrier barrier = new Barrier(2, barrier =>
        {
            Console.WriteLine($"Phase {barrier.CurrentPhaseNumber} is finished");
        });

        public void Water()
        {
            Console.WriteLine("Putting the kettle on (Takes a bit longer)");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("Puring water into the cup");
            barrier.SignalAndWait();
            Console.WriteLine("Putting the Kettle away");
        }

        public void Cup()
        {
            Console.WriteLine("Fining the nicest cup of tea (fast)");
            barrier.SignalAndWait();
            Console.WriteLine("adding tea to the cup");
            barrier.SignalAndWait();
            Console.WriteLine("adding sugar");
        }

        public void SimpleBarrierSample()
        {
            Console.WriteLine("=> SimpleBarrierSample");
            var waterTask = Task.Factory.StartNew(Water);
            var cupTask = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new[] { waterTask, cupTask }, tasks =>
             {
                 Console.WriteLine($"Enjoy your cup of tea");
             });

            tea.Wait();
        }
    }
}