using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkersList
{
    class Program
    {
        /*
         Написать программу в которой пользователь вводит имя человека и его зарплату пока не нажмет клавишу <ESC>. 
         После программа должна вывести 
            - максимальную зарплату и имя человека
            - минимальную зарплату и имя человека
            - среднюю зарплату по всем людям. 
         */
        static void Main(string[] args)
        {
            // список имен работников
            var workers = new List<string>();
            // список зарплат работников
            var salaries = new List<decimal>();

            while (true)
            {
                // ввод имени
                Console.Write("Введите имя работника: ");
                // добавляем в список работников имя работника
                workers.Add(Console.ReadLine());

                // ввод зарплаты
                Console.Write("Зарплата: ");
                // добавляем в список зарплат - зп работника
                salaries.Add(decimal.Parse(Console.ReadLine()));

                Console.WriteLine("Нажмите <ESC> для выхода");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }

            Console.WriteLine();
            
            // минимальная ЗП
            decimal minSalary = salaries.Min();
            // максимальная ЗП
            decimal maxSalary = salaries.Max();
            // средняя ЗП
            decimal average = salaries.Average();

            // вывод на экран
            Console.WriteLine($"Минимальная зарплата: {minSalary} у человека - {workers[salaries.IndexOf(minSalary)]}");
            Console.WriteLine($"Максимальная зарплата: {maxSalary} у человека - {workers[salaries.IndexOf(maxSalary)]}");
            Console.WriteLine($"Средняя зарплата: {average}");
        }
    }
}
