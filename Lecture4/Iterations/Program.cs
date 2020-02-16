using System;

namespace Iterations
{
    class Program
    {
        /*
         Программа запрашивает зарплату работников предприятия, до тех пор пока пользователь не вводит 0. 
         После ввода 0 программа выводит среднюю зарплату всех работников.
         */

        static void Main(string[] args)
        {
            decimal totalSum = 0;
            decimal count = 0;
            do
            {
                Console.Write("Enter income: ");
                decimal income = decimal.Parse(Console.ReadLine());
                if (income == 0) break;

                count = count + 1;
                totalSum = totalSum + income;
            } while (true);

            Console.WriteLine($"Average = {totalSum/count}");
        }
    }
}
