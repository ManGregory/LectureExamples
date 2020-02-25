using System;

namespace Example1
{
    /*
     Создать строку содержащую escape-последовательность табуляцию и перенос строки
     */
    class Program
    {
        static void Main(string[] args)
        {
            // для escape-последовательности используется символ слеша 
            // \t - табуляция
            // \r\n - перенос строки
            string text = "Column1\tColumn2\tColumn3\r\nRow1\tRow2\tRow3\a";

            Console.WriteLine(text);
        }
    }
}
