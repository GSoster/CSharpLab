using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int itemTypeId, string name, int price, int minDamage, int maxDamage)
            :base(itemTypeId, name, price)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        // the 'new' keyword in the method signature is to identify that this implementation hides the one from GameItem
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }

    }
}
