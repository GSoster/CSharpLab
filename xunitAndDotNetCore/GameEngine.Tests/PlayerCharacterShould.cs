using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Guilherme";
            sut.LastName = "Soster";

            Assert.Equal("Guilherme Soster",sut.FullName);
        }

        [Fact]
        public void HaveFulllNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Guilherme";
            sut.LastName = "Soster";
            Assert.StartsWith("Guilherme", sut.FullName);
        }

        [Fact]
        public void HaveFulllNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Guilherme";
            sut.LastName = "Soster";
            Assert.EndsWith("Soster", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Guilherme";
            sut.LastName = "Soster";
            Assert.Equal("Guilherme Soster", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_Substring()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Guilherme";
            sut.LastName = "Soster";
            Assert.Contains("me Sos", sut.FullName);
        }


    }
}
