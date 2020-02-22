using System;

namespace StringComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Метод string.Compare(str1, str2) для сравнения порядка строк в последовательности
            // -1 str1 предшествует str2
            // 0 str1 == str2
            // 1 str1 следует после str2
            string str1 = "Иваненко";
            string str2 = "Петренко";
            string str3 = "Буруненко";

            // -1, Иваненко предшествует Петренко
            Console.WriteLine("Сравнение {0} и {1} = {2}", str1, str2, string.Compare(str1, str2));
            // 0 Иваненко равен Иваненко
            Console.WriteLine("Сравнение {0} и {1} = {2}", str1, "Иваненко", string.Compare(str1, "Иваненко"));
            // 1 Иваненко после Буруненко
            Console.WriteLine("Сравнение {0} и {1} = {2}", str1, str3, string.Compare(str1, str3));
            // 1 Петренко после Буруненко
            Console.WriteLine("Сравнение {0} и {1} = {2}", str2, str3, string.Compare(str2, str3));

            Console.WriteLine();
            Console.WriteLine("Игнорирование регистра");
            // игнорирование регистра
            // сравнение с учетом регистра по умолчанию
            Console.WriteLine("Сравнение без игнорирования: {0}", string.Compare(str1, "иваненко"));
            // добавляем еще один параметр ignoreCase = true, чтобы сравнить без учета регистра
            Console.WriteLine("Сравнение с игнорированием: {0}", string.Compare(str1, "иваненко", true));

            Console.WriteLine();
            Console.WriteLine("Перевод в нижний и верхний регистр");
            // перевод в нижний регистр
            Console.WriteLine(str1.ToLower());
            // перевод в верхний регистр
            Console.WriteLine(str1.ToUpper());

            Console.WriteLine();
            Console.WriteLine("Проверка равенства всегда с учетом регистра");
            Console.WriteLine(str1.Equals("иваненко"));
            Console.WriteLine(str1 == "иваненко");
            Console.WriteLine(str1.ToLower() == "иваненко");

            Console.WriteLine();
            Console.WriteLine("Проверка начинается или заканчивается строка с определенных символов");
            Console.WriteLine(str1.StartsWith("Иван"));
            Console.WriteLine(str1.EndsWith("ко"));

            // string.Split()
            var words = "ab cd".Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }
    }
}
