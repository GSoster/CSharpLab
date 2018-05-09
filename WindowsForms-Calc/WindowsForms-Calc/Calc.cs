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

        #region INT type items

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

        public static int Mult (int number, int toMult)
        {
            Stack.Add(" * " + toMult.ToString());
            return number - toMult;
        }

        #endregion

        #region Double type items

        public static double Add(double number, double toAdd)
        {
            Stack.Add(" + " + toAdd.ToString());
            return number + toAdd;
        }

        public static double Sub(double number, double toSub)
        {
            Stack.Add(" - " + toSub.ToString());
            return number - toSub;
        }

        public static double Mult(double number, double toMult)
        {
            Stack.Add(" * " + toMult.ToString());
            return number - toMult;
        }

        public static double Divide (double number, double toDivide)
        {
            Stack.Add(" / " + toDivide.ToString());
            return number / toDivide;
        }

        #endregion

    }
}
