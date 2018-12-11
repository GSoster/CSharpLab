using System.Collections.ObjectModel;

namespace Engine.Models
{
    //TODO: rename this to enemy!
    public class Monster : LivingEntity
    {        
        
        public string ImageName { get; set; }                
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; private set; }        
        

        public Monster(string name, string imageName,
                       int maximumHitPoints, int hitPoints,
                       int minimumDamage, int maxmumDamage,
                       int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format($"/Engine;component/Images/Monsters/{imageName}");
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            Gold = rewardGold;
            MinimumDamage = minimumDamage;
            MaximumDamage = MaximumDamage;            
        }
    }
}
