using System;

namespace Lecture13
{
    class Program
    {
        static void Main(string[] args)
        {
            /*PrintHello();
            int num = Sum(10, 5);
            PrintNum(num);
            PrintNum(Sum(10, 20));*/

            /*int a = 5, b = 10;
            Console.WriteLine($"До: a = {a}, b = {b}");
            SwapRef(ref a, ref b);
            Console.WriteLine($"После: a = {a}, b = {b}");*/

            /*int sum = SumAndMul(10, 11, out int mul);
            Console.WriteLine($"{sum}, {mul}");

            Console.Write(TryParse("15", out int num));*/
            Console.WriteLine(SuperSum(1, 2));
            Console.WriteLine(SuperSum(1, 2, 3, 4));
            Console.WriteLine(SuperSum());
        }

        // метод с двумя целочисленными параметрами и возвращаемым целочисленным значением
        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        // метод с одним целочисленным параметром и без возвращаемого значения (void)
        static void PrintNum(int num1)
        {
            Console.WriteLine(num1);
        }

        // метод без параметров и без возвращаемого значения (void)
        static void PrintHello()
        {
            Console.WriteLine("Hello!");
        }

        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int SumAndMul(int a, int b, out int mul)
        {
            mul = a * b;
            return a + b;
        }

        /*static int SumAndMul(int a, int b, out int mul)
        {
            return a + b; // ошибка компиляции переменная mul неинициализирована
        }*/

        static bool TryParse(string input, out int num)
        {
            try
            {
                num = int.Parse(input);
            }
            catch
            {
                num = 0;
                return false;
            }
            return true;
        }

        static int SuperSum(params int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
            return sum;
        }
    }
}
