using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        //TODO: rename for something better since in the future I can implement quests chain
        //where the player needs to complete one quest, before they can receive the next quest in the “chain”.
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

    }
}
