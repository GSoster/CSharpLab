using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; }
        public int MaximumDamage { get; }

        public Weapon(int itemTypeId, string name, int price, int minDamage, int maxDamage)
            :base(itemTypeId, name, price, true)
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
