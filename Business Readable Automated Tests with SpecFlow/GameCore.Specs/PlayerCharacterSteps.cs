using System;
using TechTalk.SpecFlow;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {

        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();            
            
        }
        
        [When(@"I take 0 damage")]
        public void WhenITake0Damage()
        {
            _player.Hit(0);
        }
        
        [Then(@"My health should be 100")]
        public void ThenMyHealthShouldBe100()
        {
            Assert.Equal(100, _player.Health);
        }
    }
}
