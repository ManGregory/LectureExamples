using System;

namespace Example5
{
    class Program
    {
        /*
         Пользователь вводит размер целочисленного одномерного массива. 
         После программа предлагает заполнить значения всех элементов по очереди. 
         После на экран выводится значения введенные пользователем в обратном порядке
         */
        static void Main(string[] args)
        {
            Console.Write("Please enter array length: ");
            int arrayLen = int.Parse(Console.ReadLine());

            // создание нового массива с указанным пользователем кол-ом элементов
            int[] intArray = new int[arrayLen];

            // заполнение массива числами которые ввел пользователь
            for (int index = 0; index < intArray.Length; index++)
            {
                Console.Write($"Please enter number {index + 1} = ");
                // считываем и обрабатываем пользовательский ввод
                int userInputNum = int.Parse(Console.ReadLine());
                // записываем значение в массив
                intArray[index] = userInputNum;
            }

            // выводим значения элементов массива в порядке пользователя в одну строку
            Console.WriteLine("--Elements in user input order--");
            for (int index = 0; index < intArray.Length; index++)
            {
                Console.Write($"{intArray[index]} ");
            }
            Console.WriteLine();

            // выводим значения элементов массива в обратном порядке
            Console.WriteLine("--Elements in reverse order--");
            for (int index = intArray.Length - 1; index >= 0; index--)
            {
                Console.Write($"{intArray[index]} ");
            }
        }
    }
}
