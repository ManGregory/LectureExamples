using System;
using System.Threading;

namespace Lecture1
{
    class Program
    {
        public static int colNum = 7;
        public static int rowNum = 7;
        public static int numberOfBomb = 10;

        public static string userIcon = "P";
        public static string bombIcon = "@";
        public static int complexity = 2;
        public static string HiddenField = "*";


        static void Main(string[] args)
        {
            GameMenu();
        }


        public static void GameMenu()
        {

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
                        GameSapper();
                    }
                    else if (userChoice == 2)
                    {
                        Settings();
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

        public static void GameSapper()
        {
            GameMode();
            Gameplay();
        }

        public static void Settings()
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
                        ChangeIcon();
                    }
                    else if (userChoice == 2)
                    {
                        ChangeIcon();
                    }
                    else if (userChoice == 3)
                    {
                        ChangeComplexity();
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

        public static void ChangeIcon()
        {


            while (true)
            {
                Console.WriteLine("Введите новую иконку игрока(не больше одного символа):");
                userIcon = Console.ReadLine();

                if (userIcon.Length <= 1)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте снова");
                }
            }

        }

        public static void ChangeComplexity()
        {

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
        }

        public static void GameMode()
        {
            if (complexity == 1)
            {
                rowNum = 5;
                colNum = 5;

                numberOfBomb = 5;
            }
            else if (complexity == 2)
            {
                rowNum = 7;
                colNum = 7;
                numberOfBomb = 10;
            }
            else
            {
                rowNum = 10;
                colNum = 10;
                numberOfBomb = 25;
            }
        }



        public static void Gameplay()
        {
            int counter = 0;

            const string EntranceOrExit = "=";
            int currentPosExit = RandomPosition(rowNum);


            string[,] gameField = new string[rowNum, colNum];


            int currentPosUserCol = 0;
            int currentPosUserRow = RandomPosition(rowNum);



            int[] rowBombs = new int[numberOfBomb];
            int[] colBombs = new int[numberOfBomb];

            DrawField(gameField, ref counter, rowBombs, colBombs);

            gameField[currentPosExit, gameField.GetLength(1) - 1] = EntranceOrExit;
            gameField[currentPosUserRow, currentPosUserCol] = userIcon;



            SetBombPosition(rowBombs, colBombs, currentPosExit);


            while (true)
            {

                DrawField(gameField, ref counter, rowBombs, colBombs);

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
                    DrawField(gameField, ref counter, rowBombs, colBombs);
                    break;
                }





                if (IsPlayerLooser(currentPosUserRow, currentPosUserCol, rowBombs, colBombs) == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Поражение!!!!\n\n");
                    counter++;

                    DrawField(gameField, ref counter, rowBombs, colBombs);

                    break;
                }

            }

        }


        public static int RandomPosition(int num)
        {
            int rand = new Random().Next(0, num - 1);
            return rand;
        }

        public static void SetBombPosition(int[] rowBombs, int[] colBombs, int exit)
        {
            var rand = new Random();

            int index = 0;
            int randomRow;
            int randomCol;
            int total;

            while (index < rowBombs.Length)
            {
                total = 0;
                randomRow = rand.Next(0, rowNum);
                randomCol = rand.Next(0, colNum);

                for (int counter = 0; counter < rowBombs.Length; counter++)
                {
                    if (randomRow == rowBombs[counter] && randomRow != exit && randomCol == rowBombs[counter])
                    {
                        total += 1;
                    }
                }

                if (total == 0)
                {
                    rowBombs[index] = randomRow;
                    colBombs[index] = randomCol;
                    index++;
                }

            }
        }

        public static void DrawField(string[,] gameField, ref int counter, int[] rowBombs, int[] colBombs)
        {

            if (counter == 0)
            {
                for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
                {
                    for (int colIndex = 0; colIndex < gameField.GetLength(1); colIndex++)
                    {
                        gameField[rowIndex, colIndex] = HiddenField;
                    }
                }
                counter++;
            }


            Console.Clear();

            if (counter == 2)
            {
                for (int index = 0; index < rowBombs.Length; index++)
                {
                    gameField[rowBombs[index], colBombs[index]] = bombIcon;
                }
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
        }

        public static int IsPlayerLooser(int currentPosUserRow, int currentPosUserCol, int[] rowBombs, int[] colBombs)
        {
            int looser = 0;
            for (int index = 0; index < rowBombs.Length; index++)
            {
                if (currentPosUserRow == rowBombs[index] & currentPosUserCol == colBombs[index])
                {
                    looser += 1;
                }
            }

            return looser;
        }

    }
}
