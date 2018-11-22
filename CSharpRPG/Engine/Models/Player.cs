using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : BaseNotificationClass
    {
        #region Properties
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<QuestStatus> Quests { get; set; }
        public List<GameItem> Weapons => Inventory.Where(Item => Item is Weapon).ToList();

        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CharacterClass { get { return _characterClass; }
            set {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            } }

        public int HitPoints{ get { return _hitPoints; }
            set {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int ExperiencePoints { get { return _experiencePoints; }
            set {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int Level{ get { return _level;  }
            set {
                _level = value;
                OnPropertyChanged(nameof(Level));
            } }
        public int Gold { get { return _gold; }
            set {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            } }


        #endregion

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        //TODO: this method will be useful if we want to put a limit on the quantity or weight of items the player can have.
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
            OnPropertyChanged(nameof(Weapons));//to update the ui
        }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach(ItemQuantity item in items)
            {
                if (Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }                
            }
            return true;
        }

    }
}
