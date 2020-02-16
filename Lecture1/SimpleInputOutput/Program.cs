using System;

namespace SimpleInputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int a = 10; int b = 20; int c = 30;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("a = {0, 5}, b = {1, 5}, c = {2}", a, b, c);*/
            char main = '^';
            Console.WriteLine("{0, 3}", main);
            Console.WriteLine("{0, 2}{0, 2}", main);
            Console.WriteLine("{0, 0}{0, 2}{0, 2}", main);
        }
    }
}
