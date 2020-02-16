using System;

namespace Examples
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PrintHello(15);
            int mulResult = Mul(10, 15);
            int sumResult = Mul(15, 10);
            Console.WriteLine(mulResult);
            Console.WriteLine(sumResult);
        }

        public static int Mul(int num1, int num2)
        {
            if (num1 > num2) return num1 + num2;

            int mul = num1 * num2;
            return mul;
        }
    }
}
