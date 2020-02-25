using System;

namespace Example3
{
    /*
    Отфильтровать строку “abc1345asdfbfdasdf1233” и вывести на экран только цифры
     */
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abc1345asdfbfdasdf1233";
            // массив символов которые считаются цифрами
            // char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            foreach (char symbol in text)
            {
                // самописная реализация, лучше так не делать, используя массив digits
                // int index = Array.IndexOf(digits, symbol);
                // if (index > -1)
                // {
                //      Console.Write(symbol);
                // }

                // лучше использовать статический метод char.IsDigit
                if (char.IsDigit(symbol))
                {
                    Console.Write(symbol);
                }
            }

            // другие статические методы у класса Char, которые могут пригодится
            // проверка является ли символ буквой
            char.IsLetter('a');
            // проверка является ли символ пробелом, табуляцией и т.п.
            char.IsWhiteSpace(' ');
            // проверка является ли символ пунктуационным знаком - , -, . и т.п.
            char.IsPunctuation(',');
            // перевод символа в нижний регистр
            char.ToLower('A');
            // перевод символа в верхний регистр
            char.ToUpper('a');
        }
    }
}
