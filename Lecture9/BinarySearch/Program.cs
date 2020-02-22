using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 5, 10, 12, 14, 16, 18 };

            // искомый элемент
            int elem = 16;
            // позиция искомого элемента
            int pos = -1; 
            // нижняя граница массива
            int low = 0;
            // верхняя граница массива
            int high = arr.Length - 1;
            while (low <= high)
            {
                // индекс элемента в массиве которые будем проверять
                pos = (low + high) / 2;
                // элемент которые проверяем
                int curElem = arr[pos];
                // если нашли нужный элемент, то просто выходим из цикла
                if (curElem == elem)
                {
                    break;
                }
                // если меньше, то меняем верхнюю границу и ищем слева от текущего элемента
                else if (elem < curElem)
                {
                    high = pos - 1; // здесь была ошибка
                    // high = pos / 2 + 1 <- на два делить не надо
                }
                // если больше, то меняем нижнюю границу и ищем справа от текущего элемента
                else if (elem > curElem)
                {
                    low = pos + 1; // и здесь
                    // low = pos / 2 + 1 <- на два делить не надо
                }
            }

            // встроенная функция для бинарного поиска
            // Array.BinarySearch(arr, elem);

            // выводим на экрна индекс элемента в массиве
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
