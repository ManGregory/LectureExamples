using System;
using System.Collections.Generic;

namespace Example1
{
    class Program
    {
        /*
         Создать перечисление которое будет содержать три именованных константы: Положительное, Отрицательно и Ноль. 
         Написать функцию которая будет определять является ли число положительным, отрицательным или нулем 
         и возвращать в качестве результата перечисление.
         */

        // объявляем перечисление для определения знака числа
        enum DigitSign
        {
            Positive, // положительное число
            Negative, // отрицательное число
            Zero // ноль
        }

        // функция для определения знака числа
        static DigitSign GetDigitSign(int num)
        {
            // объявляем переменную типа перечисления DigitSign
            // по умолчанию значение ноль
            DigitSign digitSign = DigitSign.Zero;
            // число больше нуля, положительное
            if (num > 0) digitSign = DigitSign.Positive;
            // число меньше нуля, отрицательное
            if (num < 0) digitSign = DigitSign.Negative;
            // возвращаем как результат перечисления
            return digitSign;
        }

        static void Main(string[] args)
        {
            // проверяем что функция работает правильно для всех возможных случаев
            Console.WriteLine(GetDigitSign(10));
            Console.WriteLine(GetDigitSign(-10));
            Console.WriteLine(GetDigitSign(0));
        }
    }
}