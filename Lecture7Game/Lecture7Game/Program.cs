using System;

namespace Lecture7Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter field width: ");
            int rowNum = int.Parse(Console.ReadLine());
            Console.Write("Enter field height: ");
            int colNum = int.Parse(Console.ReadLine());

            // * - hidden field
            // P - player
            // @ - bomb
            // = - entrance/exit
            char[,] gameField = new char[rowNum, colNum];

            int maxBombs = 35;//rowNum * colNum / 8;
            int[,] bombIndexes = new int[maxBombs, 2];

            InitGameField(gameField);

            var generator = new Random();
            int entranceIndex = generator.Next(colNum - 1);
            int exitIndex = generator.Next(colNum - 1);
            gameField[entranceIndex, 0] = gameField[exitIndex, colNum - 1] = '=';

            GenerateBombIndexes(rowNum, colNum, maxBombs, bombIndexes, entranceIndex, exitIndex);

            int playerRow = entranceIndex;
            int playerCol = 0;
            while (true)
            {
                DrawGameField(gameField, bombIndexes, entranceIndex, exitIndex, playerRow, playerCol);

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (playerCol > 0)
                    {
                        playerCol--;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (playerCol < colNum - 1)
                    {
                        playerCol++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (playerRow > 0)
                    {
                        playerRow--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (playerRow < rowNum - 1)
                    {
                        playerRow++;
                    }
                }

                if (playerCol == colNum - 1 && playerRow == exitIndex)
                {
                    DrawGameField(gameField, bombIndexes, entranceIndex, exitIndex, playerRow, playerCol, true);
                    Console.WriteLine("You are winner!!!");
                    break;
                }

                if (OnBomb(bombIndexes, playerRow, playerCol))
                {
                    DrawGameField(gameField, bombIndexes, entranceIndex, exitIndex, playerRow, playerCol, true);
                    Console.WriteLine("You loose :-(");
                    break;
                }
            }
        }

        private static void InitGameField(char[,] gameField)
        {
            for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                {
                    gameField[rowIndex, colIndex] = '*';
                }
            }
        }

        private static void GenerateBombIndexes(int rowNum, int colNum, int maxBombs, int[,] bombIndexes, int entranceIndex, int exitIndex)
        {
            var generator = new Random();
            for (int bombIndex = 0; bombIndex < maxBombs; bombIndex++)
            {
                bool allowBomb;
                do
                {
                    int rowIndex = generator.Next(0, rowNum - 1);
                    int colIndex = generator.Next(0, colNum - 1);
                    allowBomb =
                        (colIndex != 0 || rowIndex != entranceIndex) &&
                        (colIndex != colNum - 1 || rowIndex != exitIndex);
                    if (allowBomb)
                    {
                        bombIndexes[bombIndex, 0] = rowIndex;
                        bombIndexes[bombIndex, 1] = colIndex;
                    }
                } while (!allowBomb);
            }
        }

        private static bool OnBomb(int[,] bombIndexes, int playerRow, int playerCol)
        {
            for (int bombIndex = 0; bombIndex < bombIndexes.GetLength(0); bombIndex++)
            {
                if (bombIndexes[bombIndex, 0] == playerRow && bombIndexes[bombIndex, 1] == playerCol)
                {
                    return true;
                }
            }
            return false;
        }

        private static void DrawGameField(char[,] gameField, int[,] bombs, int entranceIndex, int exitIndex, int playerRow, int playerCol, bool withBombs = false)
        {
            Console.Clear();
            for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
            {
                Console.WriteLine();
                for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                {
                    char fieldValue = gameField[rowIndex, colIndex];
                    if (withBombs && OnBomb(bombs, rowIndex, colIndex))
                    {
                        fieldValue = '@';
                    }
                    else if (rowIndex == playerRow && colIndex == playerCol)
                    {
                        fieldValue = 'P';
                    }
                    else if ((rowIndex == entranceIndex && colIndex == 0) || (rowIndex == exitIndex && colIndex == gameField.GetLength(1) - 1))
                    {
                        fieldValue = '=';
                    }
                    Console.Write($"{fieldValue}    ");
                }
                Console.WriteLine();
            }
        }
    }
}
