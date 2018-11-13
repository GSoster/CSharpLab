using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public World CurrentWorld { get; set; }
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

           

            WorldFactory wFactory = new WorldFactory();
            CurrentWorld = wFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }
    }
}
