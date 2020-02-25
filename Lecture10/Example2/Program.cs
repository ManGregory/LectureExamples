using System;

namespace Example2
{
    /*
     Создать строку с текстом “We are the champions”
        - Для этой строки найти все индексы символа ‘a’
        - Преобразовать искомую строку в строку “I am the champion” используя string.Replace
        - Разбить строку на отдельные слова и записать в массив строк
     */
    class Program
    {
        static void Main(string[] args)
        {
            string champ = "We are the champions";
            
            // найти все вхождения символа
            char symbol = 'e';
            // цикл по всем символам в строке
            for (int index = 0; index < champ.Length; index++)
            {
                // если символ совпадает с искомым, то выводим на консоль
                if (champ[index] == symbol)
                {
                    Console.WriteLine($"Index of {symbol} = {index + 1}");
                }
            }
            Console.ReadKey();

            // Преобразовать искомую строку в строку “I am the champion” используя string.Replace
            champ = champ.Replace("We", "I").Replace("are", "am").Replace("s", "");
            Console.WriteLine(champ);

            // Разбить строку на отдельные слова и записать в массив строк
            // для разбиения используется метод Split
            // первый аргумент нужен для указания какие символы использовать в качестве разделителя между словами
            // в нашем случае мы указали - , . и пробел
            string[] words = "I,    am,the, champion. You are, smug".Split(new string[] { ", ", ",", ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            // цикл по всем словам из строки после разбития
            foreach (string word in words)
            {
                // метод Trim() используется для удаления лишних пробелов в начале и конце строки
                Console.WriteLine(word.Trim());
            }
        }
    }
}
