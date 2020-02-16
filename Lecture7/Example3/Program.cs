using System;

namespace Example3
{
    class Program
    {
        /*
         * Заполнить двумерный массив случайными числами от 1 до 100. 
         * После вывести его на экран. 
         * Найти в массиве максимальный элемент и минимальный элемент, вывести их на экран вместе с их индексами.
         */
        static void Main(string[] args)
        {
            // кол-во строк
            int rows = 3;
            // кол-во столбцов
            int cols = 3;
            // создаем наш двумерный массив, таблицу
            int[,] table = new int[rows, cols];

            // заполняем таблицу случайными значениями в диапазоне от 1 до 100
            // и сразу же выводим на экран 
            var generator = new Random();
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    table[rowIndex, colIndex] = generator.Next(1, 100);
                    Console.Write("{0,5}", table[rowIndex, colIndex]);
                }
                Console.WriteLine();
            }

            // по умолчанию предпологаем что минимальный и максимальный элемент это левый верхний элемент
            // переменная для хранения индекса строки с минимальным элементом
            int minRowIndex = 0;
            // переменная для хранения индекса столбца с минимальным элементом
            int minColIndex = 0;
            // переменная для хранения индекса строки с максимальны элементом
            int maxRowIndex = 0;
            // переменная для хранения индекса столбца с максимальны элементом
            int maxColIndex = 0;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    // получаем текущий элемент
                    int curElem = table[rowIndex, colIndex];
                    // если текущий эелемент меньше минимального, значит он новый минимальный
                    if (curElem < table[minRowIndex, minColIndex])
                    {
                        // записываем индекс строки и столбца текущего элемента как индексы известного нам в данный момент минимального элемента
                        minRowIndex = rowIndex;
                        minColIndex = colIndex;
                    }
                    // если текущий эелемент больше максимального, значит он новый максимальный
                    if (curElem > table[maxRowIndex, maxColIndex])
                    {
                        // записываем индекс строки и столбца текущего элемента как индексы известного нам в данный момент максимального элемента
                        maxRowIndex = rowIndex;
                        maxColIndex = colIndex;
                    }
                }
            }

            // выводим на экран максимальный и минимальный элемент с их индексами
            Console.WriteLine($"Min element - table[{minRowIndex}, {minColIndex}] = {table[minRowIndex, minColIndex]}");
            Console.WriteLine($"Max element - table[{maxRowIndex}, {maxColIndex}] = {table[maxRowIndex, maxColIndex]}");
        }
    }
}
