using System;

namespace Example1
{
    class Program
    {
        /*
         * Создать массив из пяти элементов и заполнить его значениями: 51, 25, 48, 49, 7. Вывести массив на экран
         */
        static void Main(string[] args)
        {
            // создание массива
            int[] intArray = new int[5];

            // инициализация значений массива
            intArray[0] = 51;
            intArray[1] = 25;
            intArray[2] = 48;
            intArray[3] = 49;
            intArray[4] = 7;

            // вывод значений элементов массива на экран
            for (int index = 0; index < intArray.Length; index++)
            {
                Console.WriteLine($"Element with index {index} = {intArray[index]}");
            }
        }
    }
}
