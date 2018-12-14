using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        #region Properties
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }
        //TODO: rename for something better since in the future I can implement quests chain
        //where the player needs to complete one quest, before they can receive the next quest in the “chain”.
        public List<Quest> QuestsAvailableHere { get; } = new List<Quest>();
        public List<MonsterEncounter> MonstersHere { get; } = new List<MonsterEncounter>();
        //TODO: make traders become a list and rename this var...
        public Trader TraderHere { get; set; }

        #endregion
        public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            //Determines whether the List(T) contains elements that match the conditions defined by the specified predicate.
            if (MonstersHere.Exists(monster => monster.MonsterID == monsterID))
            {
                // significa que já temos esse monstro em nossa coleção, hora de atualizar as chances de encontrá-lo novamente
                MonstersHere.First(m => m.MonsterID == monsterID)
                            .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                //se não existir é hora de adicionar.
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }

        }



        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
                return null;

            int totalChances = MonstersHere.Sum(monster => monster.ChanceOfEncountering);

            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);
            // Loop through the monster list, 
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that is the monster to return.
            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }
            // If there was a problem, return the last monster in the list.
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }

    }
}
