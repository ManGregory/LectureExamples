using System;

namespace Example5
{
    /*
     Написать метод который принимает переменное кол-во параметров строкового типа и выводит их в обратном порядке
     */
    class Program
    {
        // ключевое слово params используется для передачи переменного кол-ва аргументов в функцию через запятую
        static void PrintParams(params string[] lines)
        {
            for (int index = lines.Length - 1; index >= 0; index--)
            {
                Console.Write($"{lines[index]} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            PrintParams("abc");
            PrintParams("abc", "def", "zxy");
            PrintParams();
        }
    }
}