using System;
using System.Collections.Generic;

namespace Example3
{
    /*
     Написать программу телефонную книгу. 
     Пользователь вводит имя человека и телефон, 
     пока не нажмет ESC. 
     После ввода данных пользователь 
     может найти номер телефона по имени человека
     */
    class Program
    {
        static void Main(string[] args)
        {
            // словарь для хранения Имени и номера телефона
            var phonebook = new Dictionary<string, string>();

            // цикл для ввода
            while (true)
            {
                Console.Write("Please enter name: ");
                string name = Console.ReadLine();
                Console.Write("Please enter phone: ");
                string phone = Console.ReadLine();

                // проверяем что человека с таким именем нет
                if (!phonebook.ContainsKey(name))
                {
                    // добавляем в телефонную книгу имя и номер телефона
                    phonebook.Add(name, phone);
                }

                Console.WriteLine("Press <ESC> to exit");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape) break;

                Console.WriteLine();
            }

            // После ввода данных пользователь 
            // может найти номер телефона по имени человека
            while (true)
            {
                Console.Write("Please enter name: ");
                string name = Console.ReadLine();

                // проверяем что человек с таким именем есть в телефонной книге
                if (phonebook.ContainsKey(name))
                {
                    // выводим на экран телефонный номер
                    Console.WriteLine($"Phone number is {phonebook[name]}");
                }
                else
                {
                    // выводим на экран что такого человека нет в телефонной книге
                    Console.WriteLine("No such name");
                }

                Console.WriteLine("Press <ESC> to exit");
                var key = Console.ReadKey(true);
                Console.WriteLine();
                if (key.Key == ConsoleKey.Escape) break;
            }
        }
    }
}
