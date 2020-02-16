using System;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameMenu();


            // создание массива с именем intArray значений типа int из 5 элементов
            // все значения по умолчанию равны 0
            int[] intArray = new int[5];

            // создание массива с именем intArray значений типа int из 5 элементов
            // сразу же инициализируем значения
            int[] intArray = new int[5] { 1, 2, 3, 4, 5 };

            // создание массива с именем intArray значений типа int
            // размерность можно не указывать т.к. это будет посчитано исходя из значения инициализации
            int[] intArray = new int[] { 1, 2 }; // массив будет создан для двух элементов

            // можно еще сократить опустив оператор new и описание типа
            int[] intArray = { 1, 2, 4 }; // массив из трех элементов типа int

            // можно задать массив как неявно типизированный используя var
            // но в таком случае нужно указать тип массива явно справа после оператора присваивания
            // иначе будет ошибка компиляции
            var array = new int[]{ 1, 2, 4 };


            for (int i = 0; i < intArray.Length; i++)
            {
                
            }

        }

        public static void GameMenu()
        {
            int counter = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\n\n\n           Choose a number!");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.Game\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2.Restart\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3.Exit\n");
                Console.ResetColor();

                string menuNum = Console.ReadLine();
                bool validNumber = Int32.TryParse(menuNum, out int gameMenuNum);

                if (validNumber)
                {

                    if (gameMenuNum == 1)
                    {
                        counter += 1;
                        GuessNumber();
                    }
                    else if (gameMenuNum == 2 && counter >= 1)
                    {
                        GuessNumber();
                    }
                    else if (gameMenuNum == 3)
                    {
                        break;
                    }
                    else if (counter < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Its your first time!!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number");
                }
            }
        }
        public static void GuessNumber()
        {
            Console.Clear();
            const string bigger = "bigger";
            const string lesser = "lesser";
            const string equal = "equal";

            int min = 1, max = 1000;

            int checkNumber = (min + max) / 2;

            while (true)
            {
                if (max - min < 2)
                {
                    Console.WriteLine($"Your number is {checkNumber}");
                    break;
                }

                Console.WriteLine($"Is number lesser, bigger or equal {checkNumber}?");
                string userAnswer = Console.ReadLine();

                if (userAnswer == bigger)
                {
                    min = checkNumber + 1;
                }
                else if (userAnswer == lesser)
                {
                    max = checkNumber - 1;
                }
                else if (userAnswer == equal)
                {
                    Console.WriteLine($"Your number is {checkNumber}");
                    break;
                }
                else
                {
                    Console.WriteLine("I dont understand, try again pls");
                }

                checkNumber = (min + max) / 2;
            }
        }



    }
}
