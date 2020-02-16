using System;

namespace Example4
{
    class Program
    {
        /*
           Заполнить двумерный массив случайными числами от 1 до 100. После вывести его на экран.
	       Посчитать сумму всех элементов в указанной строке и вывести на экран. 
           Посчитать сумму всех элементов в указанном столбце и вывести на экран.
         */
        static void Main(string[] args)
        {
            // кол-во строк
            int rows = 3;
            // кол-во столбцов
            int cols = 3;
            // создание двумерного массива или таблицы
            int[,] table = new int[rows, cols];

            // заполняем таблицу случайными значениями в диапазоне от 1 до 100
            // и сразу же выводим на экран 
            var generator = new Random();
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    table[rowIndex, colIndex] = generator.Next(1, 10);
                    Console.Write("{0,5}", table[rowIndex, colIndex]);
                }
                Console.WriteLine();
            }

            // блок ввода пользователя
            Console.Write("Enter row num for counting sum: ");
            // номер строки для которой считать сумму
            int rowNum = int.Parse(Console.ReadLine());
            Console.Write("Enter col num for counting sum: ");
            // номер столбца для которого считать сумму
            int colNum = int.Parse(Console.ReadLine());

            // расчет суммы по строке
            int rowSum = 0;
            // цикл для прохода всех элементов строки
            // при этом индекс строки остается неизменным = rowNum - 1, изменяется только индекс стобца
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                rowSum += table[rowNum - 1, colIndex];
            }

            // расчет суммы по столбцу
            int colSum = 0;
            // цикл для прохода всех элементов столбца
            // при этом индекс столбца остается неизменным = colNum - 1, изменяется только индекс строки
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                colSum += table[rowIndex, colNum - 1];
            }

            // выводим на консоль найденные значения суммы по строке и столбцу
            Console.WriteLine($"Sum for row {rowNum} = {rowSum}");
            Console.WriteLine($"Sum for columns {colNum} = {colSum}");
        }
    }
}
