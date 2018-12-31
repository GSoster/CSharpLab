using Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {

        public enum ItemCategory
        {
            Miscellaneous,
            Weapon
        }

        #region Properties
        public ItemCategory Category { get;}
        public int ItemTypeID { get; }
        public string Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }
        public AttackWithWeapon Action { get; set; }
        
        #endregion
        public GameItem(ItemCategory category, int itemTypeID, string name, int price,
                        bool isUnique = false, AttackWithWeapon action = null)
        {
            Category = category;
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            
        }

        public void PerformAction(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }

        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeID, Name, Price,
                                IsUnique, Action);
        }

        public void OnActionPerformed(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }

    }
}
