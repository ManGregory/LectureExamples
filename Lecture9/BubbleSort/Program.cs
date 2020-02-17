using System;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 8, 1, 3, 5, 9 };
            BubbleSort(arr);
            Console.WriteLine(string.Join(",", arr));
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
    }
}
