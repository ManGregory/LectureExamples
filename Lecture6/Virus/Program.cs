using System;
using System.Threading;

namespace Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Население
            long population = 0;
            // Заразность, сколько человек может заразить инфицированный
            int howMuchCanInfect = 0;
            // Вероятность заражения
            double infectProbability = 0;
            // Смертность в процентах
            double deathRate = 0;
            // Длительность болезни
            int deseaseTerm = 0;
            // Вакцина будет создана через дней
            int vaccineTerm = 0;
            // Кол-во вакцинированных людей за один день
            int vaccinePercent = 0;

            bool dataEntered = false;
            while (true)
            {
                Console.Clear();
                string userChoice = ChoiceMenu();
                if (userChoice == "1")
                {
                    Console.Clear();
                    Console.Write("Введите кол-во людей: ");
                    population = long.Parse(Console.ReadLine());
                    Console.Write("Заразность вируса, кол-во людей которое заражает один человек каждый день: ");
                    howMuchCanInfect = int.Parse(Console.ReadLine());
                    Console.Write("Вероятность заражения (от 0 до 1): ");
                    infectProbability = double.Parse(Console.ReadLine());
                    Console.Write("Смертность: ");
                    deathRate = int.Parse(Console.ReadLine());
                    Console.Write("Длительность болезни: ");
                    deseaseTerm = int.Parse(Console.ReadLine());
                    Console.Write("Вакцина будет создана: ");
                    vaccineTerm = int.Parse(Console.ReadLine());
                    Console.Write("Процент населения которой можно будет вакцинировать за 1 день: ");
                    vaccinePercent = int.Parse(Console.ReadLine());
                    dataEntered = true;
                }
                else if (userChoice == "2")
                {
                    Console.Clear();
                    //if (!dataEntered) continue;

                    //StartSimulation(population, howMuchCanInfect, infectProbability, deathRate, deseaseTerm, vaccineTerm, vaccinePercent);
                    StartSimulation(100000, 5, 0.5, 0.1, 5, 50, 0.01);
                    
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
        }

        private static void StartSimulation(int population, int howMuchCanInfect, double infectProbability, double deathRate, 
            int deseaseTerm, int vaccineTerm, double vaccinePercent)
        {
            long infectedPopulation = 1;
            long deadPeople = 0;
            //long allPopulation = population;
            long currentDay = 0;
            long[] infectedPeopleByDay = new long[deseaseTerm];
            long populationWithImmune = 0;

            do
            {                
                if (currentDay >= deseaseTerm)
                {
                    long peopleWithDesease = infectedPeopleByDay[currentDay % deseaseTerm];
                    long willDiePeople = (long)Math.Round(peopleWithDesease * deathRate);
                    populationWithImmune += peopleWithDesease - willDiePeople;
                    deadPeople += willDiePeople;
                    infectedPopulation -= peopleWithDesease;
                }

                if (infectedPopulation < population)
                { 
                    double infectWithImmuneCoef = (double)populationWithImmune / (population - deadPeople);
                    double infectCoef = howMuchCanInfect * (infectProbability - infectWithImmuneCoef);
                    long infectedToday = (long)Math.Round(infectCoef * infectedPopulation);
                    if (infectedPopulation + infectedToday >= population)
                    {
                        infectedToday = population - infectedPopulation - populationWithImmune - deadPeople;
                        infectedPopulation = population - populationWithImmune - deadPeople;
                    }
                    else
                    {
                        infectedPopulation += infectedToday;                        
                    }
                    infectedPeopleByDay[currentDay % deseaseTerm] = infectedToday;
                }

                if (currentDay >= vaccineTerm && infectedPopulation < population)
                {
                    populationWithImmune += (long)Math.Round((population - deadPeople) * vaccinePercent);
                }

                currentDay++;
                Console.WriteLine($"Day {currentDay}, infected = {infectedPopulation}");
                Console.WriteLine($"Died: {deadPeople}, has immune = {populationWithImmune}");

                if (infectedPopulation <= 0) break;
                if (deadPeople > population) break;

                Thread.Sleep(1000);                
            } while (true);

            if (infectedPopulation == 0)
            {
                Console.WriteLine($"Человечество выжило!!! Выжило - {population - deadPeople}, погибло - {deadPeople}");
            }
            else if (deadPeople >= population)
            {
                Console.WriteLine("Вирус победил, человечество вымерло :-(");
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
