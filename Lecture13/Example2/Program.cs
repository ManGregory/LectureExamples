using System;

namespace Example2
{
    /*
     Написать метод который используется для расчета суммы двух чисел и вызвать при переходе в пункт меню 1
     */
    class Program
    {
        static string HandleUserInput()
        {
            Console.WriteLine("1. Расчет");
            Console.WriteLine("2. О программе");
            Console.WriteLine("3. Выход");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string userInput = HandleUserInput();
            if (userInput == "1")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                int sum = Sum(num1, num2);
                Console.WriteLine($"Sum = {sum}");
            }
        }

        // метод принимает два целочисленных параметра и возвращает тоже число
        private static int Sum(int num1, int num2)
        {
            // return - возврат из метода
            return num1 + num2;
        }
    }
}
