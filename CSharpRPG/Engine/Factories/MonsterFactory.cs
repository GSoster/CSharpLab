﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
namespace Engine.Factories
{
    public static class MonsterFactory
    {

        public static Monster GetMonster(int monsterID)
        {
            switch(monsterID)
            {
                case 1:
                    Monster snake = 
                        new Monster("Snake", "Snake.png", 4, 4, 5, 1);
 
                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);
 
                    return snake;
 
                case 2:
                    Monster rat = 
                        new Monster("Rat", "Rat.png", 5, 5, 5, 1);
 
                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);
 
                    return rat;
                    
                case 3:
                    Monster giantSpider = 
                        new Monster("Giant Spider", "GiantSpider.png", 10, 10, 10, 3);
 
                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);
 
                    return giantSpider;
 
                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }
        //TODO: the random number should be received (to be able to unittest later)
        //TODO: the Quantity (1) should be received OR be a constant declared.
        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1)); //1 here means QUANTITY of the item.
            }
        }
    }
}
