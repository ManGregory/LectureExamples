using System;

namespace Example11
{
    class Program
    {
        /*
         Написать метод который выводит на экран меню из трех пунктов: 1. Расчет 2. О программе 3. Выход
         */

        // метод не возвращает ничего поэтому void
        // метод не принимает параметры поэтому пустые скобки
        static void PrintMenu()
        {
            Console.WriteLine("1. Расчет");
            Console.WriteLine("2. О программе");
            Console.WriteLine("3. Выход");
        }

        static void Main(string[] args)
        {
            // вызов метода
            PrintMenu();
        }
    }
}
