using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            //string infix = "(3 + (4 * 2) / (1 - 5)) / (25 - 143)";            
           
            while (true)
            {
                Console.Write("Введите арифметическое выражение: ");
                string infix = Console.ReadLine();
                double result = Evaluate(ConvertToPostfix(infix));
                Console.WriteLine($"Результат: {result}");
                Console.WriteLine("\r\nНажмите любую клавишу для продолжения или <ESC> для выхода");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }
        }

        private static string ConvertToPostfix(string expression)
        {
            StringBuilder postfixSB = new StringBuilder();

            Stack<string> stack = new Stack<string>();
            string num = string.Empty;
            foreach (char symbol in expression)
            {
                if (char.IsWhiteSpace(symbol)) continue;

                if (char.IsDigit(symbol))
                {
                    num += symbol;
                    continue;
                }

                if (!string.IsNullOrEmpty(num))
                {
                    postfixSB.Append($"{num} ");
                    num = string.Empty;
                }

                if (symbol == '(')
                {
                    stack.Push(symbol.ToString());
                }

                if (symbol == ')')
                {
                    while (stack.Count != 0 && stack.Peek()[0] != '(')
                    {
                        postfixSB.Append($"{stack.Pop()} ");
                    }
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }

                if (IsOperation(symbol))
                {
                    int curSymbolPriority = GetSymbolPriority(symbol);
                    while (stack.Count != 0 && IsOperation(stack.Peek()[0]) && GetSymbolPriority(stack.Peek()[0]) <= curSymbolPriority)
                    {
                        postfixSB.Append($"{stack.Pop()} ");
                    }
                    stack.Push(symbol.ToString());
                }
            }
            if (!string.IsNullOrEmpty(num))
            {
                postfixSB.Append($"{num} ");
            }

            while (stack.Count != 0)
            {
                postfixSB.Append($"{stack.Pop()} ");
            }
            return postfixSB.ToString();
        }

        private static double Evaluate(string expression)
        {
            var funcMap = new Dictionary<string, Func<double, double, double>>()
            {
                { "+", (num1, num2) => num1 + num2 },
                { "-", (num1, num2) => num1 - num2 },
                { "*", (num1, num2) => num1 * num2 },
                { "/", (num1, num2) => num1 / num2 }
            };
            var stack = new Stack<double>();
            var symbols = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var symbol in symbols)
            {
                if (IsOperation(symbol[0]))
                {
                    double num2 = stack.Pop();
                    double num1 = stack.Pop();
                    double res = funcMap[symbol](num1, num2);
                    stack.Push(res);
                }
                else
                {
                    stack.Push(double.Parse(symbol));
                }
            }

            return stack.Pop();
        }

        private static bool IsOperation(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        private static int GetSymbolPriority(char symbol)
        {
            var dict = new Dictionary<char, int>()
            {
                { '*', 1 },
                { '/', 1 },
                { '+', 2 },
                { '-', 2 }
            };
            return dict[symbol];
        }
    }
}
