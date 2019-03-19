using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    [Scope(Tag = "awaitingReviewBeforeStartingWork")]
    //adding scope to the class makes it be valid to every method inside the class
    public class AwaitingReviewSteps
    {
        [Given(".*")]
        [When(".*")]
        [Then(".*")]        
        public void Empty()
        {

        }
    }
}
