using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Calc
{
    public class Calc
    {
        public int Total { get; set; }

        public static List<string> Stack = new List<string>();

        public Calc ()
        {
            
        }

        public static int Add (int number, int toAdd)
        {
            Stack.Add(" + " + toAdd.ToString());
            return number + toAdd;
        }

       public static int Sub (int number, int toSub)
        {
            Stack.Add(" - " + toSub.ToString());
            return number - toSub;
        }



    }
}
