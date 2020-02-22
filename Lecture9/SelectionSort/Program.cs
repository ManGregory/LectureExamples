using System;

namespace SelectionSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 8, 1, 3, 5, 9 };
            SelectionSort(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        public static void SelectionSort(int[] arr)
        {
            // цикл по всему массиву
            for (int index = 0; index < arr.Length; index++)
            {
                int minIndex = index;
                // цикл по неотсортированной части массива
                for (int searchIndex = minIndex + 1; searchIndex < arr.Length; searchIndex++)
                {
                    if (arr[searchIndex] < arr[minIndex])
                    {
                        minIndex = searchIndex;
                    }
                }
                // ставим минимальный элемент на первую неотсортированную позицию
                int curValue = arr[index];
                arr[index] = arr[minIndex];
                arr[minIndex] = curValue;
            }
        }
    }
}
