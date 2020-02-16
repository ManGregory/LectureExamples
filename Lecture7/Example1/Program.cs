using System;

namespace Example1
{
    class Program
    {
        /*
         * Создать и заполнить значениями следующий двумерный массив - таблицу
         * 1   2   3
         * 4   5   6
         * После вывести его на экран
         */
        static void Main(string[] args)
        {
            // создаем двумерный массив, используем самую краткий вариант инициализации
            int[,] table =
            {
                { 1, 2, 3 }, // 1 строка
                { 4, 5, 6 }, // 2 строка
                { 7, 8, 9}   // 3 строка
            };

            // выводим массив на экран
            // внешний цикл для прохода по строкам
            for (int rowIndex = 0; rowIndex < table.GetLength(0); rowIndex++)
            {
                Console.WriteLine($"Это строка номер {rowIndex + 1}");
                // внутренний цикл для прохода по столбцам
                for (int colIndex = 0; colIndex < table.GetLength(1); colIndex++)
                {
                    // выводим элементы в строке через пробел
                    Console.Write($"{table[rowIndex, colIndex]}  ");
                }
                // выводим перенос строки между строками
                Console.WriteLine();
            }
        }
    }
}
