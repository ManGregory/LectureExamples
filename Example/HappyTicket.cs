using System;

namespace Lecture1
{
    class Program
    {
        public static bool IsTicketHappy(string ticketNum) 
        {
            Console.WriteLine("*Enter number 1: ");
            string s = Console.ReadLine();
            int num1 = Convert.ToInt32(s);
            Console.WriteLine("*Enter number 2: ");
            string s1 = Console.ReadLine();
            int num2 = Convert.ToInt32(s1);
            Console.WriteLine(num1 + num2 +1);
            Console.WriteLine((num1 + num2) * (num1 + num2) +1);
            
            Console.WriteLine("*Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);

            return true;
        }
    }
}