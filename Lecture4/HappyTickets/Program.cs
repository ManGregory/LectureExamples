using System;

namespace HappyTickets
{
    class Program
    {
        public static bool IsTicketHappy(int ticketNum)
        {
            int number1 = ticketNum / 100000;
            int number2 = ticketNum / 10000 % 10;
            int number3 = ticketNum / 1000 % 10;
            int number4 = ticketNum % 1000 / 100;
            int number5 = ticketNum % 100 / 10;
            int number6 = ticketNum % 10;

            int ticketNumber1 = number1 + number2 + number3;
            int ticketNumber2 = number4 + number5 + number6;

            bool isTicketHappy = ticketNumber1 == ticketNumber2;
            return isTicketHappy;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter range start: ");
                int numFrom = int.Parse(Console.ReadLine());
                Console.Write("Enter range end: ");
                int numTo = int.Parse(Console.ReadLine());
                if (numTo - numFrom > 1000)
                {
                    Console.WriteLine("Max range is 1000");
                    continue; 
                }

                for (int num = numFrom; num <= numTo; num++)
                {
                    if (IsTicketHappy(num))
                    {
                        Console.WriteLine($"Ticket {num} is happy");
                    }
                }
                Console.WriteLine("All happy tickets are displayed");
                break;
            }
        }
    }
}
