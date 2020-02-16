using System;
using System.Threading;

namespace ChristmasTreeAdvanced
{
    class Program
    {
        /*
         Нарисовать елочку, но в этот раз пользователь вводит кол-во веток у елки. 
         Размер консоли, ширина - Console.WindowWidth, высота - Console.WindowHeight, соответственно максимальное кол-во веток <= Console.WindowHeight. 
         В случае если пользователь ввел большее число, программа должна об этом сообщать. 
         Елочка должна быть выровнена по середине
         */

        static void Main(string[] args)
        {
            int ConsoleHeight = Console.WindowHeight;
            int ConsoleWidth = Console.WindowWidth;
            int branchCount = int.Parse(Console.ReadLine());
            if (branchCount <= ConsoleHeight)
            {
                int offset = 0;
                int offsetDirection = 1;
                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                    int rand = new Random((int)DateTime.Now.Ticks).Next(1, 5);
                    for (int curBranch = 1; curBranch <= branchCount; curBranch++)
                    {
                        int pos = branchCount - curBranch + offset;
                        for (int counter = 1; counter <= pos; counter++)
                        {
                            Console.Write(" ");
                        }
                        for (int counter = 1; counter < curBranch; counter++)
                        {
                            Console.Write($"{(counter % rand == 0 || curBranch % rand == 0 ? "*" : "^")} ");
                            //Console.Write("^ ");
                        }
                        Console.WriteLine();                        
                    }                    

                    if (offset >= ConsoleWidth - (branchCount * 2) && offsetDirection == 1)
                    {
                        offsetDirection = -1;
                    }
                    else if (offset <= 0 && offsetDirection == -1)
                    {
                        offsetDirection = 1;
                    }

                    offset += 5 * offsetDirection;

                    Thread.Sleep(200);
                }
            }
            Console.ReadLine();
        }
    }
}
