using System;

namespace AryphmeticOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            const int minAge = 18;
            const int sellFrom = 22;
            const int sellTo = 7;

            bool validAge = age >= minAge;
            bool validTime = hour >= sellTo && hour <= sellFrom;

            bool allowSellAlcohol = validTime && validAge;
            Console.WriteLine(allowSellAlcohol);
        }
    }
}
