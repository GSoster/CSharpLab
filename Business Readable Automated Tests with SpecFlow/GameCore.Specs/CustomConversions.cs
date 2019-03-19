using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
namespace GameCore.Specs
{
    //Specflow binding attribute makes specflow look inside this class
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransformation(int daysAgo)
        {
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }


        //it will be called every time we request a return value of type IEnumerable<Weapon>
        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponsTransformation(Table table)
        {
            //>> using TechTalk.SpecFlow.Assist;
            return table.CreateSet<Weapon>();
        }

    }
}
