using System;
using System.Diagnostics;

namespace SearchAndSort
{
    class Program
    {
        public static int BinarySearch(int[] arr, int elem)
        {
            return Array.BinarySearch(arr, elem);
        }

        public static int LinearSearch(int[] arr, int elem)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] == elem) return index;
            }
            return -1;
        }

        public static void BubbleSort(int[] arr)
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                for (int curIndex = 0; curIndex < arr.Length - index - 1; curIndex++)
                {
                    if (arr[curIndex] > arr[curIndex + 1])
                    {
                        int nextElem = arr[curIndex + 1];
                        arr[curIndex + 1] = arr[curIndex];
                        arr[curIndex] = nextElem;
                    }
                }
            }
        }

        const int ArrayLength = 10000000;
        static Random generator = new Random();

        static void GenerateArray(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                arr[index] = generator.Next(0, arr.Length);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[ArrayLength];                       

            Console.Write("Enter 1 for search, 2 for sorting: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Кол-во элементов в массиве: {ArrayLength}");
                Console.WriteLine("Кол-во поисков | Линейный поиск, с | Бинарный поиск, с");

                int searchCount = 25;
                int searchOffset = 25;

                long linearSearch;
                long binarySearch;

                for (int index = 0; index < 10; index++)
                {
                    var timer = new Stopwatch();

                    GenerateArray(arr);

                    timer.Start();
                    for (int counter = 0; counter < searchCount; counter++)
                    {
                        int elemToFind = generator.Next(0, ArrayLength);
                        LinearSearch(arr, elemToFind);
                    }
                    timer.Stop();

                    linearSearch = timer.ElapsedMilliseconds;

                    timer.Reset();

                    timer.Start();
                    Array.Sort(arr);
                    for (int counter = 0; counter < searchCount; counter++)
                    {
                        int elemToFind = generator.Next(0, ArrayLength);
                        BinarySearch(arr, elemToFind);
                    }
                    timer.Stop();

                    binarySearch = timer.ElapsedMilliseconds;

                    timer.Reset();

                    Console.WriteLine($"{searchCount,14} | {linearSearch / 1000.0,17} | {binarySearch / 1000.0,17}");

                    searchCount += searchOffset;
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Кол-во элементов | Пузырьком, с | Быстрая, с");
                int[] elementsCount = { 1000, 10000, 20000, 30000, 50000, 100000, 1000000, 10000000, 50000000, 100000000 };
                for (int index = 0; index < 10; index++)
                {
                    arr = new int[elementsCount[index]];
                    GenerateArray(arr);

                    var timer = new Stopwatch();
                    timer.Start();
                    if (arr.Length < 100000) BubbleSort(arr);
                    timer.Stop();

                    long bubbleTime = timer.ElapsedMilliseconds;

                    timer.Reset();

                    GenerateArray(arr);
                    timer.Start();
                    Array.Sort(arr);
                    timer.Stop();

                    long qsortTime = timer.ElapsedMilliseconds;

                    timer.Reset();

                    string bubble = bubbleTime == 0 ? "Долго" : (bubbleTime / 1000.0).ToString();

                    Console.WriteLine($"{elementsCount[index],16} | {bubble,12} | {qsortTime / 1000.0,10}");
                }
            }
            Console.ReadKey();
        }
    }
}
