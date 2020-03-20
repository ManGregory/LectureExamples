using System;
using System.Collections.Generic;

namespace Example2
{
    /*
     Создаеть объектную модель для задачи прохождения теста
     */

    // Вариант ответа
    class Answer
    {
        // текст варианта ответа
        public string Text { get; set; }
        // правильный/неправильный
        public bool IsCorrect { get; set; }

        // конструктор
        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        // печать на экран с номером
        public void Print(int num)
        {
            Console.WriteLine($"{num}. {Text}");
        }
    }

    // Вопрос из теста
    class Question
    {
        // текст вопроса
        public string Text { get; set; }
        // варианты ответа
        public List<Answer> Answers { get; set; }

        // печать вопроса 
        public void Print(int num)
        {
            Console.WriteLine($"Question #{num}: {Text}");
            // перемешать варианты ответов
            for (int index = 0; index < Answers.Count; index++)
            {
                Answers[index].Print(index + 1);
            }
        }

        // проверка что пользователь правильно ответил на вопрос
        // здесь можно добавить дополнительные проверки
        public bool IsUserAnswerCorrect(string userInput)
        {
            int num = int.Parse(userInput);

            return Answers[num - 1].IsCorrect;
        }
    }

    // класс для представления теста (опроса)
    class Quizz
    {
        // список вопросов на которые был дан неправильный ответ
        private List<Question> wrongQuestions;
        // Заголовок теста
        public string Title { get; set; }
        // список вопросов
        public List<Question> Questions { get; set; }

        // конструктор по умолчанию
        public Quizz()
        {
            wrongQuestions = new List<Question>();
            Questions = new List<Question>();
        }

        // прохождение теста
        public void Run()
        {            
            wrongQuestions.Clear();

            // перемешать список

            // проходим по всем вопросам
            for (int num = 0; num < Questions.Count; num++)
            {
                var question = Questions[num];
                // печатаем вопрос
                question.Print(num + 1);

                Console.Write("Please enter you variant: ");
                string userInput = Console.ReadLine();
                // проверяем ответ пользователя
                if (!question.IsUserAnswerCorrect(userInput))
                {
                    wrongQuestions.Add(question);
                }
            }

            // считаем процент ответов
            var percent = (Questions.Count - wrongQuestions.Count) / Questions.Count * 100.0;
            Console.WriteLine($"The percent: {percent}");
            Console.WriteLine("The wrong answers for next questions: ");
            // печатаем неправильные ответы
            foreach (var question in wrongQuestions)
            {
                Console.WriteLine($"{question.Text}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создание объекта теста (опроса) используя инициализатор объекта для краткости
            // очень удобно его использовать для создания многоуровневой структуры (как в нашем случае)
            var quizz = new Quizz
            {
                Title = "Test",
                Questions = new List<Question>()
                {
                    new Question
                    {
                        Text = "Distance between Dnipro and Kamenskot",
                        Answers = new List<Answer>
                        {
                            new Answer("25", false),
                            new Answer("40", true),
                            new Answer("50", false)
                        }
                    },
                    new Question
                    {
                        Text = "Какого цвета стол?",
                        Answers = new List<Answer>
                        {
                            new Answer("Black", false),
                            new Answer("White", true)
                        }
                    }
                }
            };

            // прохождение теста
            // по сути пользователю нашего класса нужно корректно создать вопросы с вариантами 
            // чтобы получить полностью работающее приложение для прохождения теста
            // все операции инкапсулированны в классе Quizz
            quizz.Run();
        }
    }
}
