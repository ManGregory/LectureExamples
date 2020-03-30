using System;
using System.Collections.Generic;

namespace ExcelExampleStruct
{
    // состояние ячейки
    enum State
    {
        NotCalculated, // еще не считалась
        Calculating, // в процессе расчета
        Calculated // посчитана
    };

    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public double Value { get; set; }
        public string Formula { get; set; }
        public bool IsCircleReference { get; set; }
        public State CalcState { get; set; }

        public string GetShowValue(bool isSymbol, int cellWidth, bool truncate = true)
        {
            if (IsCircleReference) return "!REF";

            string value = isSymbol ? Formula : Value.ToString();
            value = value ?? string.Empty;

            if (truncate && value.Length + 1 > cellWidth)
            {
                value = $"{value.Substring(0, cellWidth - 4)}...";
            }
            return value;
        }

        public string GetKey()
        {
            return $"{Row}:{Col}";
        }
    }

    class Program
    {
        // кол-во строк
        static int rows = 8;
        // кол-во столбцов
        static int cols = 8;
        // таблица для хранения формул
        static Cell[,] cells = new Cell[rows, cols];
        // текущая строка
        static int focusedRow = 1;
        // текущая колонка
        static int focusedCol = 1;
        // ширина ячейки
        const int CellWidth = 10;
        // заголовок
        const string Header = "ABCDEFGHIJKLMOPQRSTUVWXYZ";
        // это хитрая конструкция чтобы посчитать основные операции
        // Func<double, double, double> - это представление функции
        // А это (num1, num2) => num1 + num2 называется лямбда функция
        // Подобные конструкции удобно использовать если у вас большой switch
        static Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            { "+", (num1, num2) => num1 + num2 },
            { "-", (num1, num2) => num1 - num2 },
            { "*", (num1, num2) => num1 * num2 },
            { "/", (num1, num2) => num1 / num2 }
        };

        static void Main(string[] args)
        {
            InitTable();
            // отображать формулы
            bool symbol = false;
            while (true)
            {
                // рисуем таблицу
                DrawTable(symbol);

                // ввод пользователя
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
                    // показываем пользователь что вводить
                    ShowUserInput();

                    string userInput = Console.ReadLine();
                    HandleUserInput(userInput);
                    // расчет
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
                cells[focusedRow - 1, focusedCol - 1].Value = value;
                cells[focusedRow - 1, focusedCol - 1].Formula = string.Empty;
            }
            else
            {
                cells[focusedRow - 1, focusedCol - 1].Formula = userInput;
            }
        }

        // расчет всей таблицы
        private static void Calculate()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var cell = cells[row, col];
                    // если есть формула
                    if (!string.IsNullOrEmpty(cell.Formula))
                    {
                        cell.CalcState = State.NotCalculated;
                        CalcCell(cell);
                    }
                }
            }
        }

        // расчет значения в указанной ячейки
        private static void CalcCell(Cell cell)
        {
            // если ячейка уже посчитана просто возвращаем значение
            if (cell.CalcState == State.Calculated) return;

            // иначе пытаемся посчитать
            cell.CalcState = State.Calculating;
            // если есть формула для ячейки, то считаем её, иначе просто возращаем значение из таблицы чисел
            double val = string.IsNullOrEmpty(cell.Formula)
                ? cell.Value
                : CalcFormula(cell.Formula);
            // ячейка посчитана
            cell.CalcState = State.Calculated;
            cell.Value = val;
        }

        private static double CalcFormula(string formula)
        {
            // формула просто значение другой ячейки - A1
            if (formula.Length == 2)
            {
                int formulaRow = int.Parse(formula[1].ToString()) - 1;
                int formulaCol = GetColumnIndex(formula[0]);

                Cell formulaCell = cells[formulaRow, formulaCol];
                // если уже была попытка посчитать эту ячейку, значит у нас циклическая ссылка
                if (formulaCell.CalcState == State.Calculating)
                {
                    formulaCell.IsCircleReference = true;
                    return 0;
                }

                // вызываем расчет значения для ячейки (это может быть и формула и значение)
                // вот здесь как раз взаимная рекурсия
                CalcCell(formulaCell);
                return formulaCell.Value;
            }
            // формула состоит из двух операндов: A1+B1
            var operands = formula.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.RemoveEmptyEntries);
            // вот эти два последовательных вызова CalcFormula - это пример последовательной рекурсии
            // считаем левый операнд
            double leftOperand = CalcFormula(operands[0]);
            // считаем правый операнд
            double righOperand = CalcFormula(operands[1]);
            // получаем результат для ячейки
            double result = operations[formula[2].ToString()](leftOperand, righOperand);
            return result;
        }

        private static int GetColumnIndex(char column)
        {
            return Header.IndexOf(column.ToString().ToUpper());
        }

        private static void InitTable()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cells[row, col] = new Cell
                    {
                        Row = row,
                        Col = col
                    };
                }
            }
        }

        private static void DrawTable(bool isSymbol)
        {
            Console.Clear();

            for (int row = 0; row <= rows; row++)
            {
                if (row > 0)
                {
                    Console.Write($"{row,CellWidth}");
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
                        Console.Write($"{cells[row - 1, col - 1].GetShowValue(isSymbol, CellWidth),CellWidth}");
                    }
                    if (col > 0 && row == 0)
                    {
                        Console.Write($"{Header[col - 1],CellWidth}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"{Header[focusedCol - 1]}{focusedRow}: {cells[focusedRow - 1, focusedCol - 1].GetShowValue(isSymbol, CellWidth, false)}");
            Console.SetCursorPosition(focusedCol * CellWidth + CellWidth - 1, focusedRow);
        }
    }
}
