using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer{ get; set; }
        public Location CurrentLocation { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player(){
                Name = "Teste Player",
                Gold = 100000,
                CharacterClass = "Mage",
                ExperiencePoints = 0,
                HitPoints = 100,
                Level = 1
            };

            CurrentLocation = new Location()
            {
                XCoordinate = 0,
                YCoordinate = 0,
                Name = "Home",
                Description = "This is your house",
                ImageName = "/Engine;component/Images/Locations/Home.png"
            };

        }
    }
}
