using System;
using System.Threading;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMenu();
        }


        public static void GameMenu()
        {
            int complexity = 2;
            string userIcon = "P";
            string bombIcon = "@";

            while (true)
            {

                Console.WriteLine("1. Играть");
                Console.WriteLine("2. Настройки");
                Console.WriteLine("3. О программе");
                Console.WriteLine("4. Выход");


                string userNum = Console.ReadLine();

                if (int.TryParse(userNum, out int userChoice))
                {
                    if (userChoice == 1)
                    {
                        GameSapper(complexity, userIcon, bombIcon);
                    }
                    else if (userChoice == 2)
                    {
                        Settings(ref complexity, ref userIcon, ref bombIcon);
                    }
                    else if (userChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Правила игры: Вам необходимо дойти до выхода, минуя мины");
                    }
                    else if (userChoice == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Попробуйте снова!");
                    }
                }
            }
        }

        public static void GameSapper(int complexity, string userIcon, string bombIcon)
        {
            int rowNum = 0;
            int colNum = 0;
            int numberOfBomb = 0;

            GameMode(ref rowNum, ref colNum, complexity, ref numberOfBomb);

            Gameplay(numberOfBomb, rowNum, colNum, userIcon, bombIcon);

        }
        public static void Settings(ref int complexity, ref string userIcon, ref string bombIcon)
        {
            string difficult;

            while (true)
            {
                Console.Clear();
                if (complexity == 1)
                {
                    difficult = "Easy";
                }
                else if (complexity == 2)
                {
                    difficult = "Normal";
                }
                else
                {
                    difficult = "Hard";
                }


                Console.WriteLine($"1. Иконка игрока: {userIcon}");
                Console.WriteLine($"2: Иконка бомбы: {bombIcon}");
                Console.WriteLine($"3: Сложность игры: {difficult}");
                Console.WriteLine("4: Назад");


                string userNum = Console.ReadLine();

                if (int.TryParse(userNum, out int userChoice))
                {
                    if (userChoice == 1)
                    {
                        userIcon = ChangeIcon(ref userIcon);
                    }
                    else if (userChoice == 2)
                    {
                        bombIcon = ChangeIcon(ref bombIcon);
                    }
                    else if (userChoice == 3)
                    {
                        complexity = ChangeComplexity();
                    }
                    else if (userChoice == 4)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте снова!");
                    }



                }

            }
        }

        public static string ChangeIcon(ref string userIcon)
        {
            string iconPlayer;

            while (true)
            {
                Console.WriteLine("Введите новую иконку игрока(не больше одного символа):");
                iconPlayer = Console.ReadLine();

                if (iconPlayer.Length <= 1)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте снова");
                }

            }

            return iconPlayer;

        }


        public static int ChangeComplexity()
        {
            int complexity;

            while (true)
            {
                Console.WriteLine("Выберите сложность:");
                Console.WriteLine("1.Easy");
                Console.WriteLine("2.Normal");
                Console.WriteLine("3.Hard");

                string userNum = Console.ReadLine();

                bool validChoice = userNum == "1" || userNum == "2" || userNum == "3";

                if (int.TryParse(userNum, out int userChoice) && validChoice)
                {
                    complexity = userChoice;
                    break;
                }
            }

            return complexity;
        }

        public static void GameMode(ref int rows, ref int cols, int complexity, ref int numberOfBomb)
        {
            if (complexity == 1)
            {
                rows = 5;
                cols = 5;

                numberOfBomb = 10;
            }
            else if (complexity == 2)
            {
                rows = 7;
                cols = 7;
                numberOfBomb = 20;
            }
            else
            {
                rows = 10;
                cols = 10;
                numberOfBomb = 46;
            }

        }

        public static void Gameplay(int numberOfBomb, int rowNum, int colNum, string userIcon, string bombIcon)
        {

            const string HiddenField = "*";
            const string EntranceOrExit = "=";
            int looser;

            string[,] gameField = new string[rowNum, colNum];


            for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                {
                    gameField[rowIndex, colIndex] = HiddenField;
                }
            }

            int currentPosUserCol = 0;                          //Рандомлю начальную позицию игрока
            int currentPosUserRow = RandomPosition(rowNum);

            int currentPosExit = RandomPosition(rowNum);        //Рандомлю случаный выход
            gameField[currentPosExit, gameField.GetLength(1) - 1] = EntranceOrExit;

            int[] rowBombs = new int[numberOfBomb];
            int[] colBombs = new int[numberOfBomb];

            SetBombPosition(rowBombs, colBombs, rowNum); // Функция рандомит позиции бомб


            gameField[currentPosUserRow, currentPosUserCol] = userIcon;

            while (true)
            {
                looser = 0;

                Console.Clear();

                for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
                {
                    Console.WriteLine();
                    for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                    {
                        Console.Write($"{gameField[rowIndex, colIndex],5}");
                    }
                    Console.WriteLine();
                }


                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (currentPosUserCol > 0)
                    {
                        gameField[currentPosUserRow, currentPosUserCol] = HiddenField;
                        currentPosUserCol -= 1;
                        gameField[currentPosUserRow, currentPosUserCol] = userIcon;
                    }
                }

                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (currentPosUserCol < gameField.GetLength(1) - 1)
                    {
                        gameField[currentPosUserRow, currentPosUserCol] = HiddenField;
                        currentPosUserCol += 1;
                        gameField[currentPosUserRow, currentPosUserCol] = userIcon;
                    }
                }

                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentPosUserRow > 0)
                    {
                        gameField[currentPosUserRow, currentPosUserCol] = HiddenField;
                        currentPosUserRow -= 1;
                        gameField[currentPosUserRow, currentPosUserCol] = userIcon;

                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentPosUserRow < gameField.GetLength(0) - 1)
                    {
                        gameField[currentPosUserRow, currentPosUserCol] = HiddenField;
                        currentPosUserRow += 1;
                        gameField[currentPosUserRow, currentPosUserCol] = userIcon;
                    }

                }


                if (currentPosUserCol == gameField.GetLength(1) - 1 && currentPosUserRow == currentPosExit)
                {
                    Console.WriteLine("Победа!!!");
                    break;
                }


                for (int index = 0; index < rowBombs.Length; index++)
                {
                    if (currentPosUserRow == rowBombs[index] & currentPosUserCol == colBombs[index])
                    {
                        looser += 1;
                    }
                }



                if (looser == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Поражение!!!!\n\n");

                    for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
                    {
                        Console.WriteLine();
                        for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                        {
                            Console.Write($"{gameField[rowIndex, colIndex],5}");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine();


                    for (int index = 0; index < rowBombs.Length; index++)
                    {
                        gameField[rowBombs[index], colBombs[index]] = bombIcon;
                    }



                    for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
                    {
                        Console.WriteLine();
                        for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                        {
                            Console.Write($"{gameField[rowIndex, colIndex],5}");
                        }
                        Console.WriteLine();
                    }

                    break;
                }

            }

        }


        public static int RandomPosition(int num)
        {
            int rand = new Random().Next(0, num - 1);
            return rand;
        }

        public static void SetBombPosition(int[] arrayOfRows, int[] arrayOfCols, int numOfField)
        {
            var rand = new Random();

            int index = 0;
            int randomRow;
            int randomCol;
            int total;

            while (index < arrayOfRows.Length)
            {
                total = 0;
                randomRow = rand.Next(0, numOfField);
                randomCol = rand.Next(0, numOfField);

                for (int counter = 0; counter < arrayOfRows.Length; counter++)
                {
                    if (randomRow == arrayOfRows[counter] && randomCol == arrayOfCols[counter])
                    {
                        total += 1;
                    }
                }

                if (total == 0)
                {
                    arrayOfRows[index] = randomRow;
                    arrayOfCols[index] = randomCol;
                    index++;
                }

            }


        }

    }
}
