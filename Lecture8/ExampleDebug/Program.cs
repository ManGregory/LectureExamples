using System;

namespace ExampleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    int count = int.Parse(Console.ReadLine());
                    int[] arr = new int[count];

                    Console.WriteLine("Enter num of symbol in array");
                    int num = int.Parse(Console.ReadLine());

                    num = Math.Abs(num);

                    if (num > Int32.MaxValue)
                    {
                        Console.WriteLine($"Максимальная длина массива = {0}", int.MaxValue);
                        continue;
                    }

                    Console.WriteLine(arr[num - 1]);

                    int iterations = 100 / count;
                    int index = 0;
                    while (index < iterations)
                    {
                        Console.WriteLine(index);
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is IndexOutOfRangeException)
                    {

                    }
                    Console.WriteLine("Что-то пошло не так");
                }
            } while (true);
        }
    }
}
