using Engine.Models;
using Engine.Factories;
using System.Linq;
using System;
using Engine.EventArgs;
namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        #region Properties
        private Location _currentLocation;
        private Monster _currentMonster;

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer{ get; set; }

        public Weapon CurrentWeapon { get; set; }

        public Location CurrentLocation {
            get {return _currentLocation;}
            set {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToSouth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));

                CompleteQuestsAtLocation();
                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You see a {CurrentMonster.Name} here!");
                }

            }
        }
        public bool HasMonster => CurrentMonster != null; //expression body
        public bool HasLocationToNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;        
        public bool HasLocationToSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        public bool HasLocationToEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;

        public bool HasLocationToWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

        public EventHandler<GameMessageEventArgs> OnMessageRaised;

        #endregion

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

           

            
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            //test only
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
            //CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }
        }


        #region Movement Methods
        public void MoveNorth()
        {
            if (HasLocationToNorth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveSouth()
        {
            if (HasLocationToSouth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        public void MoveWest()
        {
            if (HasLocationToWest)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }
        #endregion


        private void CompleteQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                QuestStatus questToComplete = CurrentPlayer.Quests.FirstOrDefault(q => q.PlayerQuest.ID == quest.ID && !q.IsCompleted);
                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasAllTheseItems(quest.ItemsToComplete))
                    {
                        //remove the quests from the players inventory
                        foreach(ItemQuantity itemQuantity in quest.ItemsToComplete)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ItemTypeID == itemQuantity.ItemID));
                            }
                        }
                        RaiseMessage("");
                        RaiseMessage($"You completed the '{quest.Name}' quest");

                        //give quest rewards
                        //TODO: This defintelly should be in a separated function: private void ReceiveRewards(Quest)
                        CurrentPlayer.ExperiencePoints += quest.RewardExperiencePoints;
                        RaiseMessage($"You receive {quest.RewardExperiencePoints} experience points");

                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"You receive {quest.RewardGold} gold");

                        foreach (ItemQuantity itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.ItemID);

                            CurrentPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"You receive a {rewardItem.Name}");
                        }

                        // Mark the Quest as completed
                        questToComplete.IsCompleted = true;
                    }
                }
            }
        }


        //Verifies the quests that exist in the location, if the place doesn't have them yet adds it to the player quest list
        private void GivePlayerQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                //Determines whether any element of a sequence satisfies a condition.
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
                //TODO: maybe this should be somewhere else...
                // sends to the player information about the quest and rewards
                RaiseMessage("");
                RaiseMessage($"You receive the '{quest.Name}' quest");
                RaiseMessage(quest.Description);

                RaiseMessage("Return with:");
                foreach (ItemQuantity itemQuantity in quest.ItemsToComplete)
                {
                    RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                }

                RaiseMessage("And you will receive:");
                RaiseMessage($"   {quest.RewardExperiencePoints} experience points");
                RaiseMessage($"   {quest.RewardGold} gold");
                foreach (ItemQuantity itemQuantity in quest.RewardItems)
                {
                    RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                }

            }
        }

        private void GetMonsterAtLocation()
        {
            //it must be 'CurrentMonster' and not _currentMonster so we can dispache the OnPropertyChanged event.
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }


        //TODO: refactor AND rename it to AttackCurrentEnemy
        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("You must select a weapon, to attack.");
                return; //early exit
            }
            //TODO: refactor to damageToEnemy
            int damageToMonster = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            if (damageToMonster == 0)
            {
                RaiseMessage("You must select a weapon, to attack.");
            }
            else
            {
                CurrentMonster.HitPoints -= damageToMonster;
                RaiseMessage($"You hit the {CurrentMonster.Name} for {damageToMonster} points.");
            }


            //Handles the winning condition
            // If monster is killed, collect rewards and loot
            if (CurrentMonster.HitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"You defeated the {CurrentMonster.Name}!");

                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"You receive {CurrentMonster.RewardExperiencePoints} experience points.");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You receive {CurrentMonster.RewardGold} gold.");

                foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMessage($"You receive {itemQuantity.Quantity} {item.Name}.");
                }

                // Get another monster to fight
                GetMonsterAtLocation();
            }
            else //TODO: A LOT OF refactoring can be done here
            {
                // If monster is still alive, let the monster attack
                //TODO: this should be a function on the base class for the player/monster public int AttackEnemy(GameObject enemy)
                //the function should be able to determine how much damage and to damage the enemy, maybe even print it to screen..
                int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

                if (damageToPlayer == 0)
                {
                    RaiseMessage("The monster attacks, but misses you.");
                }
                else
                {
                    CurrentPlayer.HitPoints -= damageToPlayer;
                    RaiseMessage($"The {CurrentMonster.Name} hit you for {damageToPlayer} points.");
                }

                // If player is killed, move them back to their home.
                //TODO: This should be a function on player (HasDied? IsAlive? HasReceivedFatalDamage?)
                if (CurrentPlayer.HitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"The {CurrentMonster.Name} killed you.");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1); // Player's home
                    //TODO: this 10 that is multiplied by the leve to get the max life should be a constant somewhere.
                    CurrentPlayer.HitPoints = CurrentPlayer.Level * 10; // Completely heal the player
                }
            }

        }

    }
}
