using System;

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleNum = 1.2;
            var floatNum = 1.2f;
            var decimalNum = 1.2m;

            // implicit
            /*byte a = 10;
            short b = a;
            int c = b;
            long d = c;
            byte a1 = d;*/

            // explicit
            float x = 10, y = 10;            
            int a1 = (int)(x / y);
            
            // string to numbers
            int a2 = Convert.ToInt32("125");
            int a3 = int.Parse("125");
        }
    }
}
