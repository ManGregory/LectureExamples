using System;

namespace Cycles2
{
    class Program
    {
        static void Main(string[] args)
        {
            int startFrom = int.Parse(Console.ReadLine());
            int endTo = int.Parse(Console.ReadLine());
            PrintMulTable(startFrom, endTo);
        }

        /*
         * Вывести на экран таблицу умножения от 1 до 10, для чисел в диапазоне заданном пользователем.
         */
        public static void PrintMulTable(int startFrom, int endTo)
        {
            for (int curNum = startFrom; curNum <= endTo; curNum++)
            {
                Console.WriteLine($"Таблица умножения для числа {curNum}");
                for (int multiplier = 1; multiplier <= 10; multiplier++)
                {
                    Console.WriteLine($"{curNum} * {multiplier} = {curNum * multiplier}");
                }
                Console.WriteLine();
            }
        }

        /*
         * Написать функцию, которая принимает в качестве параметров начало диапазона и конец диапазона и возвращать в качестве результата сумму квадратов чисел. 
         * Если начало диапазона меньше нуля или больше конца диапазона - функция должна возвращать ноль
         */
        public static double SumOfSquare(int startFrom, int endTo)
        {
            double sum = 0;
            for (int curNum = startFrom; curNum <= endTo; curNum++)
            {
                sum += curNum * curNum;
            }
            return sum;
        }

        /*
         * Написать функцию, которая принимает в качестве параметров начало диапазона и конец диапазона и возвращать в качестве результата среднее. 
         * Если начало диапазона меньше нуля или больше конца диапазона - функция должна возвращать ноль. 
         */
        public static double Average(int startFrom, int endTo)
         {
            double sum = 0.0;
            int count = 0;
            for (int curNum = startFrom; curNum <= endTo; curNum++, count++)
            {
                sum += curNum;
            }
            return sum / count;
         }
    }
}
