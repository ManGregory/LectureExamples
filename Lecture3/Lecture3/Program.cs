using System;

namespace Lecture3
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            int monthNum = int.Parse(userInput);
            switch (monthNum)
            {
                case 2:
                    Console.WriteLine("28 дней");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30 дней");
                    break;
                default:
                    if (monthNum > 12) Console.WriteLine("Неверный ввод");  
                    else Console.WriteLine("31 день");
                    break;
            }
        }
    }
}
