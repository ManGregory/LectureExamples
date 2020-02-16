using System;

namespace Example5
{
    class Program
    {
        /*
         * Заполнить двумерный массив случайными значениями от 100000 до 999999 (это как номер билетика). 
         * Вывести этот массив на экран. 
         * После вывести массив на экран еще раз, но в этот раз нужно заменить счастливый билетик словом Happy.
         */
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 3;
            int[,] table = new int[rows, cols];

            // заполняем таблицу случайными значениями в диапазоне от 1 до 100
            // и сразу же выводим на экран 
            var generator = new Random();
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    table[rowIndex, colIndex] = generator.Next(100000, 999999);

                    Console.Write("{0,10}", table[rowIndex, colIndex]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // выводим на экран заменяя слово Happy
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    // вариант с тернарным оператором
                    // Console.Write("{0, 10}", IsTicketHappy(table[rowIndex, colIndex]) ? "Happy" : table[rowIndex, colIndex].ToString());

                    // если билетик счастиливый
                    if (IsTicketHappy(table[rowIndex, colIndex]))
                    {
                        // выводим слово Happy
                        Console.Write("{0,10}", "Happy");
                    }
                    else
                    {
                        // иначе выводим элемент массива
                        Console.Write("{0,10}", table[rowIndex, colIndex]);
                    }
                }
                Console.WriteLine();
            }
        }

        // функция для определения является ли билетик счастливым
        public static bool IsTicketHappy(int ticketNum)
        {
            int number1 = ticketNum / 100000;
            int number2 = ticketNum / 10000 % 10;
            int number3 = ticketNum / 1000 % 10;
            int number4 = ticketNum % 1000 / 100;
            int number5 = ticketNum % 100 / 10;
            int number6 = ticketNum % 10;

            int ticketNumber1 = number1 + number2 + number3;
            int ticketNumber2 = number4 + number5 + number6;

            return ticketNumber1 == ticketNumber2;
        }
    }
}
