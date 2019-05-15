namespace TaskCoordination
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Continuation Sample
            ContinuationsSample cs = new ContinuationsSample();
            cs.SimpleContinuationSample();
            System.Console.WriteLine("-----------");
            cs.ContinueWhenAllSample();
            System.Console.WriteLine("-----------");
            cs.ContinueWhenAny();

            // Child Tasks
            System.Console.WriteLine("-----------");
            System.Console.WriteLine("-----------");
            ChildTasksSample childTaskSample = new ChildTasksSample();
            childTaskSample.SimpleChildTaskSample();

            //Barriers
            System.Console.WriteLine("-----------");
            System.Console.WriteLine("-----------");
            BarrierSample barrierSample = new BarrierSample();
            barrierSample.SimpleBarrierSample();
        }
    }
}