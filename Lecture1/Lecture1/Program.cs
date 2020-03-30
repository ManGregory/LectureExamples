using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }


        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Начать работу с таблицей");
                Console.WriteLine("2. Выход");

                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    ExcelTable();
                }
                else if (userChoice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуйте еще=)");
                }
            }
        }


        public static void ExcelTable()
        {
            string[,] table = new string[9, 9];

            Moving(table);
        }

        public static void InitializationTable(string[,] table)
        {
            string[] colsTable = { "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] rowsTable = { "1", "2", "3", "4", "5", "6", "7", "8" };
            string userIcon = "!";

            for (int row = 1; row < table.GetLength(0); row++)
            {
                table[0, row] = colsTable[row - 1];
                table[row, 0] = rowsTable[row - 1];
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    table[row, col] = "0";
                }
            }

            table[1, 1] = userIcon;

        }

        public static void PrintTable(string[,] table)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(0); col++)
                {
                    Console.Write($"{table[row, col]}\t");
                }
                Console.WriteLine();
            }
        }

        public static void Moving(string[,] table)
        {

            int curRowPos = 1;
            int curColPos = 1;

            string[,] expressionInTable = new string[9, 9];

            InitializationTable(table);
            InitializationTable(expressionInTable);

            while (true)
            {
                Console.Clear();
                PrintTable(table);

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (curColPos > 1)
                    {
                        int direction = 1;
                        ChangePosition(table, ref curRowPos, ref curColPos, direction);
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (curColPos < table.GetLength(1) - 1)
                    {
                        int direction = 2;
                        ChangePosition(table, ref curRowPos, ref curColPos, direction);
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (curRowPos > 1)
                    {
                        int direction = 3;
                        ChangePosition(table, ref curRowPos, ref curColPos, direction);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (curRowPos < table.GetLength(1) - 1)
                    {
                        int direction = 4;
                        ChangePosition(table, ref curRowPos, ref curColPos, direction);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Введите в выбранную ячейку формулу или число: ");
                    string userInput = Console.ReadLine();


                    if (IsNumber(userInput))
                    {
                        expressionInTable[curRowPos, curColPos] = userInput;
                        RecalculateAllValues(expressionInTable, table);
                    }
                    else if (IsLinkSelfLoop(userInput, curRowPos, curColPos))
                    {
                        Console.WriteLine("К сожалению данная ссылка является циклической. Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        continue;
                    }
                    else if (IsLinkLoop(userInput, table, curRowPos, curColPos, expressionInTable))
                    {
                        Console.WriteLine("К сожалению данная ссылка является циклической. Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        expressionInTable[curRowPos, curColPos] = userInput;
                        RecalculateAllValues(expressionInTable, table);
                        table[curRowPos, curColPos] = CalculateValue(userInput, expressionInTable);
                    }
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    PrintValuesTable(expressionInTable);
                }
            }

        }

        public static void RecalculateAllValues(string[,] expressionInTable, string[,] table)
        {
            for (int row = 1; row < expressionInTable.GetLength(0); row++)
            {
                for (int col = 1; col < expressionInTable.GetLength(1); col++)
                {
                    if (expressionInTable[row, col] != "0")
                    {
                        table[row, col] = CalculateValue(expressionInTable[row, col], expressionInTable);
                    }
                }
            }
        }

        public static bool IsLinkLoop(string userInput, string[,] table, int currentRow, int currentCol, string[,] curExpInTable)
        {
            if (userInput.Length == 2)
            {
                return IsLinkDualLoop(userInput, curExpInTable, currentRow, currentCol);
            }

            int leftOperandRow = 0, leftOperandCol = 0;
            int rightOperandRow = 0, rightOperandCol = 0;

            string sign = Operation(userInput);
            string[] leftRightValues = GetValues(userInput, sign);
            string leftOperand = leftRightValues[0];
            string rightOperand = leftRightValues[1];

            bool isLeftOperandLoop = false;
            bool isRightOperandLoop = false;

            if (GetPosition(leftOperand, ref leftOperandRow, ref leftOperandCol) &&
                GetPosition(rightOperand, ref rightOperandRow, ref rightOperandCol))
            {
                isLeftOperandLoop = IsLinkLoop(leftOperand, table, leftOperandRow, leftOperandCol, curExpInTable);
                isRightOperandLoop = IsLinkLoop(rightOperand, table, rightOperandRow, rightOperandCol, curExpInTable);
            }

            if (isLeftOperandLoop || isRightOperandLoop)
            {
                return true;
            }

            return false;
        }


        public static bool IsLinkDualLoop(string userInput, string[,] table, int currentRow, int currentCol)
        {
            string expression = ExpressionParse(userInput, table);

            int row = 0, col = 0;

            if (expression == "0")
            {
                return false;
            }

            GetPosition(expression, ref row, ref col);

            return row == currentRow && col == currentCol;
        }

        public static bool GetPosition(string userInput, ref int row, ref int col)
        {
            if (IsNumber(userInput))
            {
                return false;
            }
            col = UserColPosition(userInput);
            row = Convert.ToInt32(Convert.ToString(userInput[1]));
            return true;
        }

        public static bool IsLinkSelfLoop(string userInput, int row, int col)
        {
            int userCol = UserColPosition(userInput);
            int userRow = Convert.ToInt32(Convert.ToString(userInput[1]));
            if (row == userRow && col == userCol)
            {
                return true;
            }

            return false;
        }

        public static void ChangePosition(string[,] table, ref int curRowPos, ref int curColPos, int direct)
        {

            if (table[curRowPos, curColPos] == "!")
            {
                table[curRowPos, curColPos] = "0";
            }

            switch (direct)
            {
                case 1:
                    curColPos--;
                    break;
                case 2:
                    curColPos++;
                    break;
                case 3:
                    curRowPos--;
                    break;
                case 4:
                    curRowPos++;
                    break;
            }

            if (table[curRowPos, curColPos] == "0")
            {
                table[curRowPos, curColPos] = "!";
            }
        }


        public static void PrintValuesTable(string[,] curExpTable)
        {
            Console.Clear();

            curExpTable[0, 0] = "";

            for (int row = 0; row < curExpTable.GetLength(0); row++)
            {
                for (int col = 0; col < curExpTable.GetLength(0); col++)
                {
                    if (curExpTable[row, col] == null)
                    {
                        curExpTable[row, col] = "0";
                    }

                    Console.Write($"{curExpTable[row, col]}\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static string CalculateValue(string userInput, string[,] table)
        {
            if (IsNumber(userInput))
            {
                return userInput;
            }
            else if (userInput.Length == 2)
            {
                return CalculateValue(ExpressionParse(userInput, table), table);
            }
            string sign = Operation(userInput);
            string[] leftRightValues = GetValues(userInput, sign);
            string leftOperand = leftRightValues[0];
            string rightOperand = leftRightValues[1];

            if (IsNumber(leftOperand))
            {
                if (IsNumber(rightOperand))
                {
                    return Calculator(leftOperand, rightOperand, sign);
                }
            }
            else
            {
                leftOperand = CalculateValue(ExpressionParse(leftOperand, table), table);
                rightOperand = CalculateValue(ExpressionParse(rightOperand, table), table);
            }

            return Calculator(leftOperand, rightOperand, sign);
        }

        //Разница в функция только в том, что в эту функцию передается не таблица с формулами, а таблица со значениями
        public static string CalculateValueWithoutRecursion(string userInput, string[,] table)
        {
            if (IsNumber(userInput))
            {
                return userInput;
            }
            else if (userInput.Length == 2)
            {
                return ExpressionParse(userInput, table);
            }

            string sign = Operation(userInput);
            string[] leftRightValues = GetValues(userInput, sign);
            string leftOperand = leftRightValues[0];
            string rightOperand = leftRightValues[1];

            return Calculator(ExpressionParse(leftOperand, table), ExpressionParse(rightOperand, table), sign);
        }


        public static string ExpressionParse(string operand, string[,] table)
        {
            int rowPosition = Convert.ToInt32(Convert.ToString(operand[1]));
            int colPosition = UserColPosition(operand);

            return table[rowPosition, colPosition];
        }

        public static bool IsNumber(string expression)
        {
            int number;

            return int.TryParse(expression, out number); ;
        }


        public static string Operation(string expression)
        {
            string currentSign = "";
            string[] sign = { "+", "-", "/", "*" };

            for (int index = 0; index < sign.Length; index++)
            {
                if (expression.IndexOf(sign[index]) != -1)
                {
                    currentSign = sign[index];
                    break;
                }
            }
            return currentSign;

        }

        public static string[] GetValues(string expressson, string sign)
        {
            return expressson.Split(sign, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int UserColPosition(string position)
        {
            var colPositions = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 },
                { 'D', 4 },
                { 'E', 5 },
                { 'F', 6 },
                { 'G', 7 },
                { 'H', 8 },
            };

            char[] symbol = position.ToCharArray();

            int collum = colPositions[symbol[0]];

            return collum;
        }


        public static string Calculator(string num1, string num2, string sign)
        {
            int result = 0;

            int number1 = Convert.ToInt32(num1);
            int number2 = Convert.ToInt32(num2);

            switch (sign)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }
            return Convert.ToString(result);
        }

    }
}
