using System;
using System.Linq;

namespace ExcelExample
{
    class Program
    {
        static int rows = 5;
        static int cols = 5;
        static string[,] symbolTable = new string[rows, cols];
        static int[,] evalTable = new int[rows, cols];
        static int focusedRow = 1;
        static int focusedCol = 1;
        const int cellWidth = 8;

        static void Main(string[] args)
        {
            bool symbol = false;
            while (true)
            {
                DrawTable(symbol);

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;

                if (key.Key == ConsoleKey.LeftArrow && focusedCol > 1)
                {
                    focusedCol--;
                }
                else if (key.Key == ConsoleKey.RightArrow && focusedCol < cols)
                {
                    focusedCol++;
                }
                else if (key.Key == ConsoleKey.UpArrow && focusedRow > 1)
                {
                    focusedRow--;
                }
                else if (key.Key == ConsoleKey.DownArrow && focusedRow < rows)
                {
                    focusedRow++;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    symbol = !symbol;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    ClearCurrentCell();

                    string userInput = Console.ReadLine();
                    HandleUserInput(userInput);
                }
            }
        }

        private static void HandleUserInput(string userInput)
        {
            bool isDigit = !string.IsNullOrWhiteSpace(userInput) && userInput.All(symbol => char.IsDigit(symbol));
            if (isDigit)
            {
                evalTable[focusedRow - 1, focusedCol - 1] = int.Parse(userInput);
                symbolTable[focusedRow - 1, focusedCol - 1] = string.Empty;
            }
            else
            {
                symbolTable[focusedRow - 1, focusedCol - 1] = userInput.Length > 8 ? userInput.Substring(0, 8) : userInput;
            }
        }

        private static void ClearCurrentCell()
        {
            Console.SetCursorPosition(focusedCol * cellWidth, focusedRow);
            Console.Write("        ");
            Console.SetCursorPosition(focusedCol * cellWidth + 1, focusedRow);
        }

        private static void DrawTable(bool symbol)
        {
            Console.Clear();
            string header = "ABCDEFGHIJKLMOPQRSTUVWXYZ";

            for (int rowIndex = 0; rowIndex <= rows; rowIndex++)
            {
                if (rowIndex > 0)
                {
                    Console.Write($"{rowIndex, cellWidth}");
                }
                for (int colIndex = 0; colIndex <= cols; colIndex++)
                {
                    if (colIndex == 0 && rowIndex == 0)
                    {
                        char space = ' ';
                        Console.Write($"{space,cellWidth}");
                    }
                    if (rowIndex > 0 && colIndex > 0)
                    {
                        Console.Write($"{(symbol ? symbolTable[rowIndex - 1, colIndex - 1] : evalTable[rowIndex - 1, colIndex - 1].ToString()),cellWidth}");
                    }
                    if (colIndex > 0 && rowIndex == 0)
                    {
                        Console.Write($"{header[colIndex - 1], cellWidth}");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(focusedCol * cellWidth + cellWidth - 1, focusedRow);
        }
    }
}
