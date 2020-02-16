using System;

namespace DnaAminoAcid
{
    class Program
    {
        static void Main(string[] args)
        {
            string dna = string.Empty;
            bool dataEntered = false;
            while (true)
            {
                Console.Clear();
                string userChoice = ChoiceMenu();
                if (userChoice == "1")
                {
                    Console.Clear();
                    Console.Write("Введите цепь ДНК: ");
                    dna = Console.ReadLine();
                    dataEntered = true;
                }
                else if (userChoice == "2")
                {
                    Console.Clear();

                    Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
        }

        private static string ChoiceMenu()
        {
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Выполнить моделирование распространения вируса");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
            return Console.ReadLine();
        }
    }
}
