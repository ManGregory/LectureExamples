using System;
using System.Collections.Generic;

namespace StackExample
{
    class Program
    {
        /*
         * Реализация стековой машины или вычисления выражений записанных в обратной польской нотации
         */
        static void Main(string[] args)
        {
            // 8 4 2 * - "8 - 4 * 2"
            string expression = "8 4 2 * -";
            // создаем стек
            Stack<int> stack = new Stack<int>();
            // разбить строку на отдельные слова (операнды либо операторы)
            string[] symbols = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // перебираем все слова - операнды либо операторы
            foreach (string symbol in symbols)
            {
                // если это знак оператор
                if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/")
                {
                    // снимаем значения/операнды со стека, 
                    int num2 = stack.Pop();
                    int num1 = stack.Pop();
                    // выполняем нужную операцию и заталкиваем в стек результат операции
                    switch (symbol)
                    {
                        case "+":
                            stack.Push(num1 + num2);
                            break;
                        case "-":
                            stack.Push(num1 - num2);
                            break;
                        case "*":
                            stack.Push(num1 * num2);
                            break;
                        case "/":
                            stack.Push(num1 / num2);
                            break;
                    }                    
                }
                // если это число
                else
                {
                    // добавляем в стек
                    stack.Push(int.Parse(symbol));
                }
            }
            // результат вычисления после цикла будет находиться на вершине стека
            Console.WriteLine($"Result of expression ({expression}) = {stack.Peek()}");
        }
    }
}