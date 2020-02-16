using System;

namespace Example3
{
    class Program
    {
        /*
         Пользователь вводит размер целочисленного одномерного массива. Необходимо:
            - Заполнить массив случайными значениями от 1 до 100 и вывести на экран.
            - После вывести на экран только четные элементы массива и их индексы
            - Вывести элементы массива в обратном порядке

         */
        static void Main(string[] args)
        {
            Console.Write("Please enter array length: ");
            int arrayLen = int.Parse(Console.ReadLine());
            
            // создаем массив с размером которое указал пользователь
            int[] intArray = new int[arrayLen];

            // заполняем массив случайными значениями
            var randGenerator = new Random();
            for (int index = 0; index < intArray.Length; index++)
            {
                intArray[index] = randGenerator.Next(1, 100);
            }

            // выводим массив со значениями на экран
            for (int index = 0; index < intArray.Length; index++)
            {
                Console.WriteLine($"Array element with index {index} = {intArray[index]}");
            }

            // выводим только четные элементы
            Console.WriteLine("--Even array elements--");
            for (int index = 0; index < intArray.Length; index++)
            {
                // проверка на четность
                if (intArray[index] % 2 == 0)
                {
                    Console.WriteLine($"Array element with index {index} = {intArray[index]}");
                }
            }

            // выводим элементы массива в обратном порядке
            // обратите внимание что цикл фор работает в обратную сторону от последнего элемента массива к нулевому
            Console.WriteLine("--Array elements in reverse order--");
            for (int index = intArray.Length - 1; index >= 0; index--)
            {
                Console.WriteLine($"Array element with index {index} = {intArray[index]}");
            }

            // Метод Array.Reverse физически поменяет местами элементы в массиве
            // Array.Reverse(intArray);
        }
    }
}
