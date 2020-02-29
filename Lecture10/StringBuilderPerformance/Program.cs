using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderPerformance
{
    class Program
    {
        /*
         Пример сравенения производительности разных методов конкатенации строк
          - конкатенация с использованием оператор +=
          - конкатенация с использованием StringBuilder.Append
         */
        static void Main(string[] args)
        {
            // количество итераций
            const int IterCount = 100000;
            // текст который будет добавляться указанное IterCount кол-во раз
            string text = "abcd";

            // переменная в которой будет результат конкатенации строки IterCount кол-во раз
            string concatText = string.Empty;
            // создаем секундомер
            Stopwatch timer = new Stopwatch();
            // и запускаем его
            timer.Start();
            // в цикле просто добавляем к нашей переменной переменную text с использованием оператор +=
            for (int iter = 0; iter < IterCount; iter++)
            {
                concatText += text;
            }
            // останавливаем секундомер
            timer.Stop();
            // записываем время выполнения в миллисекундах в переменную
            long concatTime = timer.ElapsedMilliseconds;

            // сбрасываем секундомер
            timer.Reset();

            // создаем экземпляр класса StringBuilder
            StringBuilder concatSb = new StringBuilder();
            // стартуем таймер
            timer.Start();
            // в цикле добавляем в наш StringBuilder concatSb переменную text с использованием метода Append
            for (int iter = 0; iter < IterCount; iter++)
            {
                concatSb.Append(text);
            }
            // получаем результат конкатенации в concatTextSb
            string concatTextSb = concatSb.ToString();
            // остнавливаем секундомер
            timer.Stop();
            // записываем время выполнения в миллисекундах в переменную
            long sbConcatTime = timer.ElapsedMilliseconds;

            // выводим на экран результатов замеров разныех способов конкатенации
            // в первую очередь проверяем что получили правильный результат
            Console.WriteLine($"Строки полученные обоими методами равны concatText == concatTextSb = {concatText == concatTextSb}");
            Console.WriteLine($"Конкатенация строк строка + строка - {concatTime/1000.0} c");
            Console.WriteLine($"Конкатенация строк с использованием StringBuilder - {sbConcatTime/1000.0} c");            
        }
    }
}