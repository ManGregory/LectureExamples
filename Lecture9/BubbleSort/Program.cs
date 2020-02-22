using System;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 345, 5, 8, 1, 3, 5, 9, 1555 };
            BubbleSort(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        public static void BubbleSort(int[] arr)
        {
            // цикл по всему массиву
            for (int index = 0; index < arr.Length - 1; index++)
            {
                // цикл по неотсортированной части
                // максимальный элемент всплывет на последнюю позицию
                bool hasSwap = false;
                for (int curIndex = 0; curIndex < arr.Length - index - 1; curIndex++)
                {
                    // сравниваем текущий элемент и следующий
                    if (arr[curIndex] > arr[curIndex + 1])
                    {
                        // обмен элементов массива
                        hasSwap = true;
                        int nextElem = arr[curIndex + 1];
                        arr[curIndex + 1] = arr[curIndex];
                        arr[curIndex] = nextElem;
                    }
                }
                if (!hasSwap)
                {
                    break;
                }
            }

            Array.Sort(arr);
        }
    }
}
