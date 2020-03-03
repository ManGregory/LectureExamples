using System;
using System.Collections.Generic;

namespace Example2
{
    class Program
    {
        /*
         Создать словарь для хранения пар ИНН - ФИО. 
            - Добавить несколько пар ключ-значение
            - Изменить значение 
            - Попробовать добавить ИНН, который уже есть
            - Осуществить поиск по определенному ИНН
            - Вывести на экран все пары
         */
        static void Main(string[] args)
        {
            // создаем словарь и инициализируем его начальными значениями
            // словарь будет использоваться для хранения пар ИНН - ФИО
            // в качестве ключа используется тип int (ИНН - это число)
            // в качестве значения используется тип string (ФИО - это текст)
            var dict = new Dictionary<int, string>()
            {
                { 123456789, "Петренко Иван" },
                { 345667786, "Иванов Иван" },
                { 345667785, "Иванов Иван" },
                { 345667784, "Жиглов Леонид" }
            };
            /*
            другой способ инициализации словаря
            {
                [123456789] = "Петренко Иван",
                [345667786] = "Иванов Иван"
            };*/

            // добавляем новое значение в словарь
            dict.Add(345565654, "Нестор Летописец");

            // попытка добавить значение с уже существующим ключом приведет к ArgumentException
            //dict.Add(345667786, "asdfasdf"); // <- ArgumentException
            // здесь не будет эксепшена, но значение не будет добавлено или перезаписано
            //dict.TryAdd(345667786, "asdfasdf");

            // обращаемся к нашему словарю по индексу
            // если такой ключ уже есть, то его значение будет заменено
            dict[123456789] = "Петренко Андрей";
            
            // проверка наличия ключа
            if (dict.ContainsKey(1211221)) // false
            {
                // замена значения
                dict[1211221] = "zxcvzxcv";
            }
            else
            {
                // добавления нового ключа
                dict.Add(1211221, "asdfasdf");
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Search");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Show");

                string userChoice = Console.ReadLine();

                Console.Write("Please enter inn: ");
                int inn = int.Parse(Console.ReadLine());

                if (userChoice == "1")
                {
                    // поиск
                    // проверяем наличия ключа
                    if (dict.ContainsKey(inn))
                    {
                        // выводим на экран значение ИНН и ФИО
                        // ФИО получаем по ключу из словаря dict[inn]
                        Console.WriteLine($"The human with inn - {inn}, Name - {dict[inn]}");
                    }
                    else
                    {
                        // такого инн нет в нашем словаре, предлагаем добавить
                        Console.WriteLine($"The human with such inn - {inn} is not exist");
                        Console.Write("Please enter name for inn: ");
                        string name = Console.ReadLine();
                        // добавляем ИНН и ФИО в словарь
                        dict.Add(inn, name);
                    }
                }
                else if (userChoice == "2")
                {
                    // удаление значения из словаря по ключу
                    dict.Remove(inn);
                }
                else if (userChoice == "3")
                {
                    // обновляем значение по ИНН
                    Console.Write("Please enter name for inn: ");
                    string name = Console.ReadLine();
                    // если ИНН нет в словаре, то оно будет добавлено
                    // если ИНН есть в словаре, то значение будет заменено
                    dict[inn] = name;
                }
                else if (userChoice == "4")
                {
                    // вывод на экран ИНН через запятую
                    Console.WriteLine(string.Join(",", dict.Keys));
                    // вывод на экран ФИО через запятую
                    Console.WriteLine(string.Join(",", dict.Values));

                    // вывод всех пар ИНН - ФИО
                    /*foreach (var keyValue in dict)
                    {
                        Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
                    }*/

                    // вывод всех пар ИНН - ФИО, способ №2
                    foreach (var key in dict.Keys)
                    {
                        Console.WriteLine($"{key} - {dict[key]}");
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}
