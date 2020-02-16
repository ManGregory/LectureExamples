using System;

namespace LoopInIL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sum: ");
            decimal sum = Decimal.Parse(Console.ReadLine());
            Console.Write("Term: ");
            int term = int.Parse(Console.ReadLine());
            Console.Write("Percent: ");
            decimal percent = Decimal.Parse(Console.ReadLine());
            Console.Write("Cap (Y/N): ");
            bool hasCap = Console.ReadLine().ToUpperInvariant().StartsWith('Y');

            decimal depoSum = sum;
            decimal monthPercent = percent / 12 / 100;
            for (int month = 1; month <= term; month++)
            {
                decimal curMonthSum = depoSum;
                decimal percentAmount = depoSum * monthPercent;
                depoSum += hasCap ? percentAmount : 0;
                Console.WriteLine($"Month - {month}, Sum begin - {curMonthSum:N2}, Sum end - {depoSum:N2}, Percent - {percentAmount:N2}");
            }
        }
    }
}
