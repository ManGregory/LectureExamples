using System;

namespace Menu_example
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal average = 0;
            decimal day = 0;
            decimal night = 0;
            decimal totalCost = 0;
            bool dataEntered = false;
            while (true)
            {
                Console.Clear();
                string userChoice = ChoiceMenu();
                if (userChoice == "1")
                {
                    Console.Clear();
                    Console.Write("Среднемесячное потребление (кВт): ");
                    average = decimal.Parse(Console.ReadLine());
                    Console.Write("Дневной тариф (грн/кВт): ");
                    day = decimal.Parse(Console.ReadLine());
                    Console.Write("Ночной тариф (грн/кВт): ");
                    night = decimal.Parse(Console.ReadLine());
                    Console.Write("Стоимость установки счетчика (грн): ");
                    totalCost = decimal.Parse(Console.ReadLine());
                    dataEntered = true;
                }
                else if (userChoice == "2")
                {
                    Console.Clear();
                    if (!dataEntered) continue;

                    Console.WriteLine($"Среднемесячное потребление в кВт - {average}");
                    Console.WriteLine($"Тариф дневной грн/кВт - {day}, Тариф ночной грн/кВт - {night}");
                    Console.WriteLine($"Расходы на установку счетчика - {totalCost}");

                    Console.WriteLine("Процент | Однофазный | Двухфазный | Срок окупаемости");
                    for (int percent = 10; percent <= 50; percent += 5)
                    {
                        decimal averageOneZoneCost = average * day;
                        decimal averageTwoZoneCost = average * day * (1 - percent / 100.0M) + average * night * percent / 100.0M;
                        decimal term = totalCost / (averageOneZoneCost - averageTwoZoneCost);
                        Console.WriteLine($"{percent,8}{Math.Round(averageOneZoneCost, 2), 12:N2}{Math.Round(averageTwoZoneCost, 2),12:N2}{Math.Round(term, 0),15}");
                    }
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
        }

        public static int GetSquare(int num)
        {
            return num * num;
        }

        public static double GetSquare(double num)
        {
            return num * num;
        }

        private static string ChoiceMenu()
        {
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Выполнить расчет");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
            return Console.ReadLine();
        }
    }
}