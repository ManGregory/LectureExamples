using System;
using System.Threading;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool BoolVariableForTryCatch = true;

            do
            {
                int summary = 0;
                int difference = 0;
                int multiply = 1;
                int division = 1;
                int sum = 0;
                int mul = 1;
                int QuantityOfElements = 0;

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Возможные операции: +, -, *, /, sum, mul");
                Console.WriteLine("Введите желаемую операцию: ");
                string operation = Console.ReadLine();

                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    do
                    {

                        try
                        {
                            BoolVariableForTryCatch = true;
                            Console.WriteLine();

                            Console.WriteLine("Введите первое число:");
                            int number1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите второе число:");
                            int number2 = int.Parse(Console.ReadLine());

                            switch (operation)
                            {

                                case "+":

                                    summary = number1 + number2;
                                    Console.WriteLine($"Сумма чисел - {summary}");

                                    break;

                                case "-":

                                    difference = number1 - number2;
                                    Console.WriteLine($"Разница чисел - {difference}");

                                    break;

                                case "*":

                                    multiply = number1 * number2;
                                    Console.WriteLine($"Произведение чисел - {multiply}");

                                    break;

                                case "/":

                                    division = number1 / number2;
                                    Console.WriteLine($"Частное чисел - {division}");

                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Скорее всего, вы ввели не число, попробуйте ещё раз ");
                            Console.ResetColor();
                            Console.WriteLine();

                            BoolVariableForTryCatch = false;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("К сожалению, делить на ноль нельзя :( ");
                            Console.ResetColor();
                            Console.WriteLine();
                            BoolVariableForTryCatch = false;
                        }


                    } while (BoolVariableForTryCatch == false);
                }

                else if (operation == "sum" || operation == "mul")
                {

                    do
                    {
                        BoolVariableForTryCatch = true;

                        try
                        {
                            BoolVariableForTryCatch = true;
                            Console.WriteLine("Введите количество элементов в массиве: ");

                            int numbersForOperation = int.Parse(Console.ReadLine());
                            int[] OperationArray = new int[numbersForOperation];

                            for (int OperationIterator = 0; OperationIterator < OperationArray.Length; OperationIterator++)
                            {
                                Console.Write($"Введите значение {OperationIterator + 1} элемента: ");


                                int ElementsCount = int.Parse(Console.ReadLine());
                                OperationArray[OperationIterator] = ElementsCount;
                            }

                            bool SumMul = true;
                            switch (operation)
                            {

                                case "sum":
                                    do //Если пользователь вводит отрицательное количество элементов для расчёта суммы, программа снова просит ввести кол-во элементов
                                    {
                                        SumMul = true;
                                        Console.WriteLine($"Введите количество элементов для расчёта суммы");
                                        QuantityOfElements = int.Parse(Console.ReadLine());

                                        if (QuantityOfElements <= 0)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine("количество элементов для расчёта суммы не может быть меньше нуля");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            SumMul = false;
                                        }

                                    } while (SumMul == false);

                                    for (int sumIterator = 0; sumIterator < QuantityOfElements; sumIterator++)
                                    {
                                        sum += OperationArray[sumIterator];
                                    }

                                    Console.WriteLine($"Сумма элементов массива - {sum}");
                                    break;

                                case "mul":
                                    {

                                        do
                                        {
                                            SumMul = true;

                                            Console.WriteLine($"Введите количество элементов для расчёта произведения");
                                            QuantityOfElements = int.Parse(Console.ReadLine());

                                            if (QuantityOfElements <= 0)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Yellow;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.WriteLine("количество элементов для расчёта произведения не может быть меньше нуля");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                SumMul = false;
                                            }

                                        } while (SumMul == false);

                                        for (int mulIterator = 0; mulIterator < QuantityOfElements; mulIterator++)
                                        {
                                            mul *= OperationArray[mulIterator];
                                        }

                                        Console.WriteLine($"Произведение элементов массива - {mul}");
                                        break;
                                    }
                            }
                        }

                        catch (OverflowException)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Количество элементов в массиве не может быть отрицательным/ настолько большим ");
                            Console.ResetColor();
                            Console.WriteLine();
                            BoolVariableForTryCatch = false;
                        }

                        catch (FormatException)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Скорее всего, вы ввели не число, попробуйте ещё раз ");
                            Console.ResetColor();
                            Console.WriteLine();
                            BoolVariableForTryCatch = false;
                        }

                        catch (IndexOutOfRangeException)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Количество элементов для расчёта не может быть больше, чем количество элементов в массиве ");
                            Console.ResetColor();
                            Console.WriteLine();
                            BoolVariableForTryCatch = false;
                        }

                    } while (BoolVariableForTryCatch == false);

                }
                Console.WriteLine("Нажмите Esc, если хотите выйти; чтоб продолжить - нажмите любую другую клавишу");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    // прерываем бесконечный цикл
                    break;
                }
                Console.Clear();
            } while (true);

        }
    }
}
