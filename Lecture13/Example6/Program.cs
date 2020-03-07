using System;

namespace Example6
{
    /*
     - Написать метод для расчета факториала
     - Написать метод для расчета чисел Фибоначчи
     - Написать метод для линейного поиска используя рекурсию
     */
    class Program
    {
        // факториал
        static int Factorial(int num)
        {
            if (num == 1) return 1; // условие выхода, факториал 1 = 1

            // факториал любого числа это число умноженное на факториал числа - 1
            // 5! = 5 * 4!
            return num * Factorial(num - 1);
        }

        // числа фибоначчи
        static int Fibonacci(int num)
        {
            // нулевое число фибоначчи = 0
            if (num <= 0) return 0;
            // первое число = 1
            if (num == 1) return 1;

            // остальные это Фибоначи(число - 1) + Фибоначи(число - 2)
            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }

        static int LinearSearch(int[] arr, int num, int startIndex)
        {
            // условие выхода, индекс больше длины массива
            if (startIndex >= arr.Length) return -1;
            // элемент найден, возвращаем результат
            if (arr[startIndex] == num) return startIndex;

            // элемент не был найден, ищем во всем остальном массиве
            return LinearSearch(arr, num, startIndex + 1);
        }

        static void Main(string[] args)
        {
            // Расчет факториала
            Console.WriteLine(Factorial(5));

            // Числа Фибоначчи
            // 0 1 1 2 3 5 8 13 
            Console.WriteLine(Fibonacci(-1));
            Console.WriteLine(Fibonacci(0));
            Console.WriteLine(Fibonacci(1));
            Console.WriteLine(Fibonacci(7));

            // Линейный поиск
            int[] arr = { 8, 9, 1, 10, 5, 7 };
            Console.WriteLine($"Index of element 8 = {LinearSearch(arr, 8, 0)}");
            Console.WriteLine($"Index of element 7 = {LinearSearch(arr, 7, 0)}");
            Console.WriteLine($"Index of element 10 = {LinearSearch(arr, 10, 0)}");
            Console.WriteLine($"Index of element 145 = {LinearSearch(arr, 145, 0)}");
        }
    }
}
