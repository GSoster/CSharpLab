using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
namespace Engine.Factories
{
    internal class WorldFactory//internal to only be usable inside Engine project/namespace
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.addLocation(new Location() {
                XCoordinate = 0,
                YCoordinate = -1,
                Name = "Home",
                Description = "This is your world",
                ImageName = "/Engine;component/Images/Locations/Home.png"
            });

            newWorld.addLocation(new Location()
            {
                XCoordinate = -2,
                YCoordinate = -1,
                Name = "Farm's Field",
                Description = "There are rows of corn growing here, with giant rats hiding among them.",
                ImageName = "/Engine;component/Images/Locations/FarmFields.png"
            });

            newWorld.addLocation(new Location()
            {
                XCoordinate = -1,
                YCoordinate = -1,
                Name = "Farm's House",
                Description = "This is the house of your neighbor, Farmer Ted.",
                ImageName = "/Engine;component/Images/Locations/Farmhouse.png"
            });

            newWorld.addLocation(new Location()
            {
                XCoordinate = -1,
                YCoordinate = 0,
                Name = "Trading Shop",
                Description = "The shop of Susan, the trader.",
                ImageName = "/Engine;component/Images/Locations/Trader.png"
            });


            newWorld.addLocation(new Location()
            {
                XCoordinate = 0,
                YCoordinate = 0,
                Name = "Town square",
                Description = "You see a fountain here.",
                ImageName = "/Engine;component/Images/Locations/TownSquare.png"
            });

            newWorld.addLocation(new Location()
            {
                XCoordinate = 1,
                YCoordinate = 0,
                Name = "Town Gate",
                Description = "There is a gate here, protecting the town from giant spiders.",
                ImageName = "/Engine;component/Images/Locations/TownGate.png"
            });


            newWorld.addLocation(new Location()
            {
                XCoordinate = 2,
                YCoordinate = 0,
                Name = "Spider Forest",
                Description = "The trees in this forest are covered with spider webs.",
                ImageName = "/Engine;component/Images/Locations/SpiderForest.png"
            });


            newWorld.addLocation(new Location()
            {
                XCoordinate = 0,
                YCoordinate = 1,
                Name = "Herbalist's hut",
                Description = "You see a small hut, with plants drying from the roof.",
                ImageName = "/Engine;component/Images/Locations/HerbalistsHut.png"
            });


            newWorld.addLocation(new Location()
            {
                XCoordinate = 0,
                YCoordinate = 1,
                Name = "Herbalist's garden",
                Description = "There are many plants here, with snakes hiding behind them.",
                ImageName = "/Engine;component/Images/Locations/HerbalistsGarden.png"
            });

     

            return newWorld;
        }
    }
}
