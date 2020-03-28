using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelExample
{
    class Program
    {
        static int rows = 8;
        static int cols = 8;
        static string[,] symbolTable = new string[rows, cols];
        static double[,] calcTable = new double[rows, cols];
        static int focusedRow = 1;
        static int focusedCol = 1;
        const int CellWidth = 10;
        const string Header = "ABCDEFGHIJKLMOPQRSTUVWXYZ";
        static Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            { "+", (num1, num2) => num1 + num2 },
            { "-", (num1, num2) => num1 - num2 },
            { "*", (num1, num2) => num1 * num2 },
            { "/", (num1, num2) => num1 / num2 }
        };

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
                    ShowUserInput();

                    string userInput = Console.ReadLine();
                    HandleUserInput(userInput);
                    Calculate();
                }
            }
        }

        private static void ShowUserInput()
        {
            Console.SetCursorPosition(0, rows + 2);
            Console.Write($"Enter value or formula for cell {Header[focusedCol - 1]}{focusedRow}: ");
        }

        private static void HandleUserInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput)) return;

            bool isDigit = double.TryParse(userInput, out double value);
            if (isDigit)
            {
                calcTable[focusedRow - 1, focusedCol - 1] = value;
                symbolTable[focusedRow - 1, focusedCol - 1] = string.Empty;
            }
            else
            {
                symbolTable[focusedRow - 1, focusedCol - 1] = userInput;                
            }
        }

        enum State
        {
            NotVisited,
            Visiting,
            Visited
        };

        static Dictionary<string, State> evaluated = new Dictionary<string, State>();

        private static void Calculate()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!string.IsNullOrEmpty(symbolTable[row, col]))
                    {
                        var treeState = new Dictionary<string, State>();
                        double cellVal = CalcCell(row, col, treeState);
                        if (treeState.ContainsKey("Circle"))
                        {
                            cellVal = 0;
                        }
                        calcTable[row, col] = cellVal;
                    }
                }
            }
        }

        private static double CalcCell(int row, int col, Dictionary<string, State> treeState)
        {
            string item = Header[col] + row.ToString();
            if (treeState.ContainsKey(item) && treeState[item] == State.Visited)
            {
                return calcTable[row, col];
            }

            treeState.Add(item, State.Visiting);
            string formula = symbolTable[row, col];
            double val = string.IsNullOrEmpty(formula)
                ? calcTable[row, col]
                : CalcFormula(formula, treeState);

            treeState[item] = State.Visited;
            return val;
        }

        private static double CalcFormula(string formula, Dictionary<string, State> treeState)
        {
            if (formula.Length == 2)
            {
                int formulaRow = int.Parse(formula[1].ToString()) - 1;
                int formulaCol = GetColumnIndex(formula[0]);

                var item = Header[formulaCol] + formulaRow.ToString();
                if (treeState.ContainsKey(item) && treeState[item] == State.Visiting)
                {
                    treeState.Add("Circle", 0);
                    return 0;
                }

                return CalcCell(formulaRow, formulaCol, treeState);
            }
            var operands = formula.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.RemoveEmptyEntries);
            double leftOperand = CalcFormula(operands[0], treeState);
            double righOperand = CalcFormula(operands[1], treeState);
            double result = operations[formula[2].ToString()](leftOperand, righOperand);
            return result;
        }

        private static int GetColumnIndex(char column)
        {
            return Header.IndexOf(column.ToString().ToUpper());
        }

        private static void DrawTable(bool isSymbol)
        {
            Console.Clear();            

            for (int row = 0; row <= rows; row++)
            {
                if (row > 0)
                {
                    Console.Write($"{row, CellWidth}");
                }
                for (int col = 0; col <= cols; col++)
                {
                    if (col == 0 && row == 0)
                    {
                        char space = ' ';
                        Console.Write($"{space,CellWidth}");
                    }
                    if (row > 0 && col > 0)
                    {
                        Console.Write($"{GetShowValue(row, col, isSymbol),CellWidth}");
                    }
                    if (col > 0 && row == 0)
                    {
                        Console.Write($"{Header[col - 1], CellWidth}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"{Header[focusedCol - 1]}{focusedRow}: {GetShowValue(focusedRow, focusedCol, isSymbol, false)}");
            Console.SetCursorPosition(focusedCol * CellWidth + CellWidth - 1, focusedRow);
        }

        private static string GetShowValue(int row, int col, bool isSymbol, bool truncate = true)
        {
            string value = isSymbol ? symbolTable[row - 1, col - 1] : calcTable[row - 1, col - 1].ToString();
            value = value ?? string.Empty;

            if (truncate && value.Length + 1 > CellWidth)
            {
                value = $"{value.Substring(0, CellWidth - 4)}...";
            }
            return value;
        }
    }
}