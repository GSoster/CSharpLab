using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class BreaksCancellationsAndExceptions
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private ParallelOptions po = new ParallelOptions();

        public void Demo()
        {
            po.CancellationToken = cts.Token;

            var result = Parallel.For(0, 20, po, (x, state) =>
            {
                if (x == 10)
                {
                    //state.Stop();
                    //state.Break();
                    //throw new Exception();//Throws Aggregate Excpetion
                    cts.Cancel();//it trhows exception of type OperationCancelledException
                }
            });

            Console.WriteLine($"Was loop completed? {result.IsCompleted}");
        }
    }
}