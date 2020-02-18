using System;
using System.Linq;

namespace TestExample
{
    class Program
    {
        private static string[] questions =
        {
            "Расстояние между Днепром и Каменским в км?",
            "Кто написал Хоббита?",
            "Основатель Майкрософт?"
        };
        private static string[,] answers =
        {
            {"10", "20", "30", "40" },
            {"Толкиен", "Достоевский", "Киплинг", "Дед Мороз" },
            {"Джобс", "Ильф и Петров", "Билл Гейтс", "Сталин" }
        };
        private static int[] rightAnswerIndex = { 3, 0, 2 };
        private static int[] wrongQuestionIndex = new int[3] { -1, -1, -1 };
        private static int[] randQuestions = { 0, 1, 2 };
        private static int[] randAnswers = { 0, 1, 2, 3 };

        private static Random generator = new Random();

        private static void Shuffle(int[] arr)
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int randIndex = generator.Next(index, arr.Length);
                int temp = arr[index];
                arr[index] = arr[randIndex];
                arr[randIndex] = temp;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                for (int index = 0; index < wrongQuestionIndex.Length; index++)
                {
                    wrongQuestionIndex[index] = -1;
                }

                Shuffle(randQuestions);
                for (int questionIndex = 0; questionIndex < randQuestions.Length; questionIndex++)
                {
                    Console.Clear();
                    int realQuestionIndex = randQuestions[questionIndex];
                    string question = questions[realQuestionIndex];
                    Console.WriteLine($"{questionIndex + 1}. {question}");

                    Shuffle(randAnswers);
                    for (int answerIndex = 0; answerIndex < answers.GetLength(1); answerIndex++)
                    {
                        int realAnswerIndex = randAnswers[answerIndex];
                        string answer = answers[realQuestionIndex, realAnswerIndex];
                        Console.WriteLine($"{answerIndex + 1}. {answer}");
                    }

                    int userAnswer = int.Parse(Console.ReadLine()) - 1;
                    int realIndex = randAnswers[userAnswer];
                    if (realIndex != rightAnswerIndex[realQuestionIndex])
                    {
                        wrongQuestionIndex[questionIndex] = realQuestionIndex;
                    }
                }

                Console.Clear();
                int correctCount = wrongQuestionIndex.Count(elem => elem == -1);
                Console.WriteLine($"Процент правильных ответов: {Math.Round(correctCount * 1.0 / questions.Length * 100.0, 2)}%");

                if (correctCount < questions.Length)
                {
                    Console.WriteLine("Следующие вопросы были отвечены неверно:");

                    for (int index = 0; index < wrongQuestionIndex.Length; index++)
                    {
                        if (wrongQuestionIndex[index] != -1)
                        {
                            Console.WriteLine($"\t{questions[wrongQuestionIndex[index]]}");
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите <ENTER> чтобы пройти тест еще раз или <ESC> для выхода");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }            
        }
    }
}
