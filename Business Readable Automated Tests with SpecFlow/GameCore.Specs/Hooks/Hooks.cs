using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    ///
    /// This file describes the existing hooks possibilities..
    /// We inherit from Steps so it is possible to use the 
    /// ScenarioInfo in a thread safe way by the use of the "THIS" keyword
    
    public class Hooks : Steps
    {
        [BeforeTestRun]
        public static void BeforeTestRun(){}

        [BeforeFeature]
        public static void BeforeFeature() { }

        [BeforeScenario("elf")]//will only execute before scenarios with tag elf
        public void BeforeScenario(){}

        [BeforeScenarioBlock] // group of steps in a scenario
        public void BeforeScenarioBlock() { }

        [BeforeStep]
        public void BeforeStep() { }

        [AfterStep]
        public void AfterStep() { }

        [AfterScenarioBlock] // group of steps in a scenario
        public void AfterScenarioBlock() { }

        [AfterScenario]
        public void AfterScenario(){}

        [AfterFeature]
        public static void AfterFeature() { }

        [AfterTestRun]
        public static void AfterTestRun() { }

    }
}
