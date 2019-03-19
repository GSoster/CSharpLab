using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    ///
    /// We inherit from Steps so it is possible to use the 
    /// ScenarioInfo in a thread safe way by the use of the "THIS" keyword
    public class Hooks : Steps
    {

        [BeforeScenario("elf")]//will only execute before scenarios with tag elf
        public void BeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
