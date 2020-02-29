using System;
using System.Threading;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userWantToExit = false;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1. Играть!");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. О программе...");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("3. Выход.");

                    Console.ResetColor();

                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            userUnput();
                            break;

                        case ConsoleKey.D2:
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Привет Игрок!" +
                                                "\n В этой игре, тебе предстоит преодолеть трудный путь, от входа и до выхода." +
                                                "\n \"Почему трудный?\" - спросишь ты," +
                                                "\n \"А потому что бомбы!\" - отвечу тебе я!" +
                                                "\n На игровом поле расставлены бомбы, наступив на которые, ты проиграешь!" +
                                                "\n По какому принципц расставлены бомбы - одному Богу известно и поэтому я могу лишь пожелать тебе удачи!" +
                                                "\n Удачи Игрок!");
                            Console.WriteLine("\n Чтобы перейти в главное меню, нажмите любую клавишу...");
                            Console.ResetColor();

                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case ConsoleKey.D3:
                            Console.Clear();
                            userWantToExit = true;
                            break;
                    }
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите пожалуйста цифру!");
                }

            } while (userWantToExit == false);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("До встречи!");
            Console.ResetColor();
        }

        public static void userUnput()
        {
            int fieldSize = 10;
            bool inputIsCorrect = false;
            int healthpoint = 3;
            int bombsNum = 5;

            Console.ForegroundColor = ConsoleColor.Yellow;

            do
            {
                try
                {
                    do
                    {
                        Console.Write("Введите размерность поля: ");
                        fieldSize = int.Parse(Console.ReadLine());

                        if (fieldSize >= 8)
                        {
                            inputIsCorrect = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Размерность поля должна быть не меньше 8!!!");
                        }

                    } while (inputIsCorrect == false);

                    Console.Write("Введите кол-во бомбочек: ");
                    bombsNum = int.Parse(Console.ReadLine());

                    do
                    {
                        Console.Write("Введите кол-во ваших игровых жизней: ");
                        healthpoint = int.Parse(Console.ReadLine());
                        Console.Clear();


                        if (healthpoint > 0)
                        {
                            inputIsCorrect = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Нельзя иметь 0 очков жизней, это как-то неправильно)");
                        }

                    } while (inputIsCorrect == false);

                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Введите пожалуйста цифру!");
                }
            } while (inputIsCorrect == false);

            TheGame(fieldSize: fieldSize, bombsNum: bombsNum, healthpoint: healthpoint); ;
        }

        public static void TheGame(int fieldSize, int bombsNum, int healthpoint)
        {
            int userWin = 1945; // просто какое-то значение

            int rowNum = fieldSize;
            int colNum = fieldSize;
            // символы которые будут использоваться на игровом поле
            const char HiddenField = '*';
            const char Player = 'P';
            const char Bomb = '@';
            const char Entrance = '|';
            const char Exit = '}';
            const char detonatedBomb = 'X';

            // двумерный массив для игрового поля, что будет выводиться пользователя 
            char[,] userField = new char[rowNum, colNum];

            // двумерный массив для хранения игрового поля
            char[,] gameField = new char[rowNum, colNum];

            // инициализация игрового поля
            for (int rowIndex = 0; rowIndex < userField.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < userField.GetLength(1); colIndex++)
                {
                    userField[rowIndex, colIndex] = HiddenField;
                    gameField[rowIndex, colIndex] = HiddenField;
                }
            }
            var generate = new Random();


            // вход
            int y = generate.Next(0, 10);
            userField[y, 0] = Entrance;
            gameField[y, 0] = Entrance;

            //условия для места генерации игрока
            int x;
            if (y != 0 && y != 9)
            {
                x = generate.Next(1, 2);
            }
            else
            {
                x = generate.Next(1, 3);
            }

            userField[y, 0 + x] = Player;
            int playerPositionX = x;
            int playerPositionY = y;

            // выход
            y = generate.Next(0, 10);
            userField[y, rowNum - 1] = Exit;
            gameField[y, rowNum - 1] = Exit;

            // генератор бомб
            for (int bombGeneratedAmount = 0; bombGeneratedAmount < bombsNum; bombGeneratedAmount++)
            {
                int bombRow = generate.Next(0, rowNum - 1);
                int bombCol = generate.Next(0, colNum - 1);

                if (bombRow == playerPositionY && bombCol == playerPositionX)
                {
                    if (bombGeneratedAmount > 0)
                    {
                        bombGeneratedAmount -= 1;
                    }
                    continue;
                }
                else
                {
                    gameField[bombRow, bombCol] = Bomb;
                }
            }

            //-------------------------------//

            while (true)
            {
                // на каждом шаге игры рисуем игровое поле
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int rowIndex = 0; rowIndex < userField.GetLength(0); rowIndex++)
                {
                    Console.WriteLine();
                    for (int colIndex = 0; colIndex < userField.GetLength(1); colIndex++)
                    {
                        if (userField[rowIndex, colIndex] == Player)
                        {
                            playerPositionY = rowIndex;
                            playerPositionX = colIndex;
                        }
                        Console.Write($"{userField[rowIndex, colIndex],5}");
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Осталось очков жизни: {healthpoint}");
                Console.ResetColor();


                // здесь будет происходить обработка действий пользователь
                // получаем клавишу которую нажал пользователь
                var key = Console.ReadKey();

                // если клавиша Escape - пользователь устал и хочет закончить игру
                if (key.Key == ConsoleKey.Escape)
                {
                    // прерываем бесконечный цикл
                    userWin = 3;
                    break;
                }
                // нажата стрелка влево
                else if (key.Key == ConsoleKey.LeftArrow && playerPositionX - 1 != -1 && gameField[playerPositionY, playerPositionX - 1] != Entrance)
                {
                    if (gameField[playerPositionY, playerPositionX - 1] == Exit)
                    {
                        userWin = 1;
                        break;
                    }
                    else
                    {
                        userField[playerPositionY, playerPositionX] = HiddenField;
                        userField[playerPositionY, playerPositionX - 1] = Player;
                    }
                }
                // нажата стрелка вправо
                else if (key.Key == ConsoleKey.RightArrow && playerPositionX + 1 != colNum)
                {
                    if (gameField[playerPositionY, playerPositionX + 1] == Exit)
                    {
                        userWin = 1;
                        break;
                    }
                    else
                    {
                        userField[playerPositionY, playerPositionX] = HiddenField;
                        userField[playerPositionY, playerPositionX + 1] = Player;
                    }
                }
                // нажата стрелка вверх
                else if (key.Key == ConsoleKey.UpArrow && playerPositionY - 1 != -1 && gameField[playerPositionY - 1, playerPositionX] != Entrance)
                {
                    if (gameField[playerPositionY - 1, playerPositionX] == Exit)
                    {
                        userWin = 1;
                        break;
                    }
                    else
                    {
                        userField[playerPositionY, playerPositionX] = HiddenField;
                        userField[playerPositionY - 1, playerPositionX] = Player;
                    }
                }
                // нажата стрелка вниз
                else if (key.Key == ConsoleKey.DownArrow && playerPositionY + 1 != rowNum && gameField[playerPositionY + 1, playerPositionX] != Entrance)
                {

                    if (gameField[playerPositionY + 1, playerPositionX] == Exit)
                    {
                        userWin = 1;
                        break;
                    }
                    else
                    {
                        userField[playerPositionY, playerPositionX] = HiddenField;
                        userField[playerPositionY + 1, playerPositionX] = Player;
                    }
                }

                if (gameField[playerPositionY, playerPositionX] == Bomb)
                {
                    healthpoint -= 1;
                    userField[playerPositionY, playerPositionX] = detonatedBomb;
                    gameField[playerPositionY, playerPositionX] = detonatedBomb;

                    if (healthpoint == 0)
                    {
                        userWin = 0;
                        break;
                    }
                }
            }

            Console.Clear();

            // Поле что показывается игроку после резуальтата игры
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int rowIndex = 0; rowIndex < userField.GetLength(0); rowIndex++)
            {
                Console.WriteLine();
                for (int colIndex = 0; colIndex < userField.GetLength(1); colIndex++)
                {
                    Console.Write($"{gameField[rowIndex, colIndex],5}");
                }
                Console.WriteLine();
            }
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Red;
            if (userWin == 0)
            {
                Console.WriteLine("В следующий раз повезёт!");
            }
            else if (userWin == 1)
            {
                Console.WriteLine("Вы победили, примите мои поздравления!");
            }
            else if (userWin == 3)
            {
                Console.WriteLine("Жаль, что не хотите доиграть...");
            }
            Console.ResetColor();
            Console.WriteLine("Чтобы вернутся в главное меню, нажимте любую кнопку.");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
