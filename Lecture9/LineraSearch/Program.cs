using System;

namespace LineraSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 5, 1, 10, 11 };

            int elem = 1;
            // позиция искомого элемента в массиве, встроенный метод
            int pos = Array.IndexOf(arr, elem);
            // реализация поиска
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] == elem)
                {
                    // элемент найден
                    pos = index;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine($"Element {elem} is not in array");
            }
            else
            {
                Console.WriteLine($"Element {elem} is on {pos}");
            }
        }
    }
}
