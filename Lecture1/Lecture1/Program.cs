using System;
using System.Threading;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartCalculator();
        }

        public static void SmartCalculator()
        {


            string[] arrayOfOperations = { "+", "-", "*", "/", "sum", "mul" };

            int userChoice;
            int userNum1 = 0, userNum2 = 0;
            int userAmount = 0;
            int[] userArray = new int[0];


            do
            {
                Console.WriteLine("\n\nВведите операцию:");

                for (int index = 0; index < arrayOfOperations.Length; index++)
                {
                    Console.WriteLine($"{index + 1}:{arrayOfOperations[index]}");
                }

                try
                {

                    userChoice = Convert.ToInt32(Console.ReadLine());


                    if (0 < userChoice && userChoice < 5)
                    {
                        Console.WriteLine("Введите два числа:");
                        userNum1 = Convert.ToInt32(Console.ReadLine());
                        userNum2 = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (5 <= userChoice && userChoice <= 7)
                    {
                        try
                        {
                            Console.WriteLine("Введите длинну массива");
                            int userLenght = Convert.ToInt32(Console.ReadLine());

                            userArray = new int[userLenght];

                            Console.WriteLine("Введите элементы массива");
                            for (int index = 0; index < userArray.Length; index++)
                            {
                                userArray[index] = Convert.ToInt32(Console.ReadLine());
                            }


                            Console.WriteLine("Введите количество элементов для операции:");
                            userAmount = Convert.ToInt32(Console.ReadLine());
                        }

                        catch (OverflowException)
                        {
                            Console.Clear();
                            Console.WriteLine("Слишком большой или отрицательный размер массива");
                        }
                    }

                    double result;

                    switch (userChoice)
                    {
                        case 1:
                            if (Sum(userNum1, userNum2, out result))
                            {
                                Console.WriteLine(result);
                            }
                            break;

                        case 2:
                            Console.WriteLine(Diff(userNum1, userNum2));
                            break;

                        case 3:
                            if (Mult(userNum1, userNum2, out result))
                            {
                                Console.WriteLine(result);
                            }
                            break;

                        case 4:
                            if (Div(userNum1, userNum2, out result))
                            {
                                Console.WriteLine(result);
                            }
                            break;

                        case 5:
                            if (SumArray(userArray, userAmount, out result))
                            {
                                Console.WriteLine(result);
                            }
                            break;

                        case 6:
                            if (MultArray(userArray, userAmount, out result))
                            {
                                Console.WriteLine(result);
                            }
                            break;

                        default:
                            Console.WriteLine("Missed =)");
                            break;
                    }



                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте еще раз! В этот раз вводите цифры");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Слишком большое число");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }



        public static bool Sum(int userNum1, int userNum2, out double result)
        {
            result = 1;
            Console.Clear();
            try
            {
                result = checked(userNum1 + userNum2);
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Слишком большие значения");
                return false;
            }
            return true;
        }
        public static int Diff(int userNum1, int userNum2)
        {
            Console.Clear();
            return userNum1 - userNum2;
        }
        public static bool Mult(int userNum1, int userNum2, out double result)
        {
            result = 1;
            Console.Clear();
            try
            {
                result = checked(userNum1 * userNum2);
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Слишком большие значения");
                return false;
            }
            return true;
        }
        public static bool Div(int userNum1, int userNum2, out double div)
        {
            div = 0;

            try
            {
                div = userNum1 / userNum2;
            }
            catch (DivideByZeroException)
            {
                Console.Clear();
                Console.WriteLine("На ноль делить нельзя");
                return false;
            }

            return true;
        }

        public static bool SumArray(int[] userArray, int userAmount, out double sumArr)
        {
            sumArr = 0;
            try
            {
                for (int index = 0; index < userAmount; index++)
                {
                    sumArr = checked(sumArr + userArray[index]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("В массиве нет столько элементов");
            }
            catch (System.StackOverflowException)
            {
                Console.WriteLine("Слишком большое итоговое значение");
                return false;
            }

            return true;
        }

        public static bool MultArray(int[] userArray, int userAmount, out double multArr)
        {
            multArr = 1;
            try
            {
                for (int index = 0; index < userAmount; index++)
                {
                    multArr = checked(multArr * userArray[index]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("В массиве нет столько элементов");
                return false;
            }
            catch (System.StackOverflowException)
            {
                Console.WriteLine("Слишком большое итоговое значение");
                return false;
            }

            return true;
        }
    }
}
