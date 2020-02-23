using System;
using System.Collections.Generic;

namespace StackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 4 +
            var stack = new Stack<int>();
            string expression = "6 3 4 + 4 + +";
            var symbols = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var symbol in symbols)
            {
                if (symbol == "+")
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    int res = num1 + num2;
                    stack.Push(res);
                }
                else
                {
                    stack.Push(int.Parse(symbol));
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
