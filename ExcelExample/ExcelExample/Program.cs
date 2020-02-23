using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelExample
{
    class Program
    {
        static int rows = 5;
        static int cols = 5;
        static string[,] symbolTable = new string[rows, cols];
        static int[,] calcTable = new int[rows, cols];
        static int focusedRow = 1;
        static int focusedCol = 1;
        const int cellWidth = 8;
        const string header = "ABCDEFGHIJKLMOPQRSTUVWXYZ";

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
                    Calculate();
                }
            }
        }

        private static void HandleUserInput(string userInput)
        {
            bool isDigit = !string.IsNullOrWhiteSpace(userInput) && userInput.All(symbol => char.IsDigit(symbol));
            if (isDigit)
            {
                calcTable[focusedRow - 1, focusedCol - 1] = int.Parse(userInput);
                symbolTable[focusedRow - 1, focusedCol - 1] = string.Empty;
            }
            else
            {
                symbolTable[focusedRow - 1, focusedCol - 1] = userInput.Length > 8 ? userInput.Substring(0, 8) : userInput;                
            }
        }

        private static void Calculate()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!string.IsNullOrEmpty(symbolTable[row, col]))
                    {
                        calcTable[row, col] = CalcCell(row, col);
                    }
                }
            }
        }

        private static int CalcCell(int row, int col)
        {
            int val = calcTable[row, col];
            string formula = symbolTable[row, col];
            if (string.IsNullOrEmpty(formula)) return val;

            return CalcFormula(formula);
        }

        static Dictionary<string, Func<int, int, int>> operations = new Dictionary<string, Func<int, int, int>>()
        {
            { "+", (num1, num2) => num1 + num2 },
            { "-", (num1, num2) => num1 - num2 },
            { "*", (num1, num2) => num1 * num2 },
            { "/", (num1, num2) => num1 / num2 }
        };

        private static int CalcFormula(string formula)
        {
            if (formula.Length == 2)
            {
                int formulaRow = int.Parse(formula[1].ToString()) - 1;
                int formulaCol = GetColumnIndex(formula[0]);

                return CalcCell(formulaRow, formulaCol);
            }
            var operands = formula.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.RemoveEmptyEntries);
            int leftOperand = CalcFormula(operands[0]);
            int righOperand = CalcFormula(operands[1]);
            int result = operations[formula[2].ToString()](leftOperand, righOperand);
            return result;
        }

        private static int GetColumnIndex(char column)
        {
            return header.IndexOf(column.ToString().ToUpper());
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
                        Console.Write($"{(symbol ? symbolTable[rowIndex - 1, colIndex - 1] : calcTable[rowIndex - 1, colIndex - 1].ToString()),cellWidth}");
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
