using System;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int monthAverage = 0;
            decimal dailyRate = 0;
            decimal nightRate = 0;
            decimal cost = 0;
            do
            {
                Console.Write("Меню:\n1) Ввод данных\n2) Выполнить расчет\n3) Выход\n\nВаше выбор: ");
                string symbol = Console.ReadLine();
                i = int.Parse(symbol);

                switch (i)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Среднемесячное потребление в кВт: ");
                        monthAverage = int.Parse(Console.ReadLine());
                        Console.WriteLine(("").PadRight(24, '-'));
                        Console.Write("Тариф дневной (грн/кВт): ");
                        dailyRate = decimal.Parse(Console.ReadLine());
                        Console.Write("Тариф ночной(грн/кВт): ");
                        nightRate = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(("").PadRight(24, '-'));
                        Console.WriteLine("Стоимость за установку счетчика: ");
                        cost = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        bool chek = monthAverage == 0 && dailyRate == 0 && nightRate == 0 && cost == 0;
                        if (chek)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы не ввели данные.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Payment(monthAverage, dailyRate, nightRate, cost);
                            break;
                        }
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы решили выйти");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
                Console.Write("\n\nНажмите любую клавишу чтобы вернуться в меню...");
                Console.ReadLine();
                Console.Clear();
            }
            while (i != 3);


        }
        public static decimal Payment(int monthAverage, decimal dailyRate, decimal nightRate, decimal cost)
        {

            int persent = 10;
            decimal sum = 0;
            decimal month = 0;
            Console.WriteLine($"Среднемесячное потребление в кВт: {monthAverage}");
            Console.WriteLine($"Тариф дневной грн/кВт: {dailyRate}");
            Console.WriteLine($"Тариф ночной грн/кВт: {nightRate}");
            Console.WriteLine($"Стоимость за установку счетчика {cost} ");

            Console.WriteLine("\n\n Процент\t Однофазный\t Двухфазный\t Срок окупаемости");
            Console.WriteLine(("").PadRight(30, '-'));
            while (persent < 55)
            {
                /*decimal dayPercent = 100 - persent;
                decimal day = dayPercent / 100 * monthAverage;*/
                decimal sumDay = dailyRate * ((100 - persent) / 100.0M * monthAverage);
                //decimal sumDay = dailyRate * day;
                decimal night = monthAverage * persent / 100;
                decimal sumNight = nightRate * night;
                decimal biphasic = sumNight + sumDay;
                decimal singlePhase = monthAverage * dailyRate;
                sum = singlePhase - biphasic;
                month = cost / sum;
                Console.WriteLine($"\n{persent}\t\t {singlePhase:f2}\t\t {biphasic:f2}\t\t {month:f0}");
                persent = persent + 5;

            }
            return month;

        }

    }
}
