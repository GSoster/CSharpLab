using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUnique { get; set; }

        public GameItem(int itemTypeId, string name, int price, bool isUnique = false)
        {
            ItemTypeID = itemTypeId;
            Name = name;
            Price = price;
            IsUnique = IsUnique;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemTypeID, Name, Price, IsUnique);
        }

    }
}
