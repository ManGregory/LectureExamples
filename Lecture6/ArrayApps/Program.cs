using System;
using System.Linq;

namespace ArrayApps
{
    class Program
    {
        /*
            Написать функцию, которая принимает в качестве входного параметра целочисленный массив 
            и возвращает как результат true - если сумма элементов больше нуля, иначе false
         */

        static void Main(string[] args)
        {
            Console.WriteLine(IsArraySumPositive(new int[] { 10, 20, -50 }));
            Console.WriteLine(IsArraySumPositive(new int[] { 10, 20, 50 }));
            Console.WriteLine(IsArraySumPositive(new int[] { 0, 10, -10}));
        }

        public static bool IsArraySumPositive(int[] arr)
        {
            int sum = 0
            /*int sum = 0;
            for (int index = 0; index < arr.Length; index++)
            {
                sum += arr[index];
            }*/
            return sum >= 0;
        }
    }
}
