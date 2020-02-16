using System;

namespace Lecture7GameTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            // ширина поля
            int rowNum = 10;
            // длина поля
            int colNum = 10;

            // символы которые будут использоваться на игровом поле, можете менять как хотите
            const char HiddenField = '*';
            const char Player = 'P';
            const char Bomb = '@';
            const char EntranceOrExit = '=';

            // двумерный массив для хранения игрового поля
            char[,] gameField = new char[rowNum, colNum];

            // инициализация игрового поля
            for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                {
                    gameField[rowIndex, colIndex] = HiddenField;
                }
            }

            // здесь нужно написать код для генерации
            //  - расположения бомб
            //  - расположения входа/выхода

            // любая игра - это всегда бесконечный цикл
            // пока пользователь не победит/проиграет или просто не захочет закончить игру
            while (true)
            {
                // на каждом шаге игры рисуем игровое поле
                Console.Clear();
                for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
                {
                    Console.WriteLine();
                    for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                    {
                        Console.Write($"{gameField[rowIndex, colIndex],5}");
                    }
                    Console.WriteLine();
                }

                // здесь будет происходить обработка действий пользователь
                // получаем клавишу которую нажал пользователь
                var key = Console.ReadKey();

                // если клавиша Escape - пользователь устал и хочет закончить игру
                if (key.Key == ConsoleKey.Escape)
                {
                    // прерываем бесконечный цикл
                    break;
                }
                // нажата стрелка влево
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    
                }
                // нажата стрелка вправо
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    
                }
                // нажата стрелка вверх
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    
                }
                // нажата стрелка вниз
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    
                }

                // здесь нужно написать условия окончания игры
                //  - пользователь добрался до выхода, победа
                //  - пользователь подорвался на мине, лузер
            }
        }
    }
}
