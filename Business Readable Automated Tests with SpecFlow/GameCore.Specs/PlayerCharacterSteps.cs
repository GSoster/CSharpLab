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
        

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }

        
        [Then(@"My health should be (.*)")]
        public void ThenMyHealthShouldBe(int expectedHealth)
        {
            Assert.Equal(expectedHealth, _player.Health);
        }


        [Then(@"I should be dead")]
        public void IShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

    }
}
