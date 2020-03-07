using System;

namespace Example4
{
    /*
     Написать метод, который может преобразовать строку в число. 
     Если число в неправильном формате то метод должен возвращать false. 
     Само число нужно вернуть с помощью out параметра
     */

    class Program
    {
        // метод возвращает логическое значение, которое говорит была ли операция успешна
        // второй параметр возвращает результат преобразования
        // если преобразование не удалось то num = 0
        static bool TryParse(string text, out double num)
        {
            // переменную нужно обязательно инициализировать до возврата из метода
            // иначе будет ошибка компиляции
            num = 0; 
            try
            {
                num = double.Parse(text);
            }
            catch
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string textNum = Console.ReadLine();

            if (TryParse(textNum, out double num))
            {
                Console.WriteLine($"Num = {num}");
            }
            else
            {
                Console.WriteLine("Введено не число");
            }
        }
    }
}
