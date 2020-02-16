using System;

namespace Example2
{
    class Program
    {
        /*
         * Пользователь вводит кол-во строк и столбцов в таблице. 
         * Необходимо заполнить двумерный массив случайными числами в диапазоне от 1 до 100. После вывести на экран таблицу.
         */
        static void Main(string[] args)
        {
            // блок ввода
            Console.Write("Enter row num: ");
            // кол-во строк
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter col num: ");
            // кол-во столбцов
            int cols = int.Parse(Console.ReadLine());

            // создание двумерного массива
            int[,] table = new int[rows, cols];

            // заполняем таблицу, случайными значениями
            // в диапазоне от 1 до 100
            // создаем генератор псевдослучайных чисел
            var generator = new Random();
            // внешний цикл для прохода по строкам
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                // внутренний цикл для прохода по столбцам
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    // генерируем значение и записываем в наш двумерный массив / таблицу
                    table[rowIndex, colIndex] = generator.Next(50, 100);
                    // выводим значение на экран
                    Console.Write("{0,5}", table[rowIndex, colIndex]);
                }
                Console.WriteLine();
            }
        }
    }
}
