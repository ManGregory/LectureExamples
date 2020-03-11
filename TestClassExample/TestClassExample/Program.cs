using System;
using System.Collections.Generic;

namespace TestClassExample
{
    class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public void Print(int num)
        {
            Console.WriteLine($"{num}. {Text}");
        }
    }

    class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }

        public void AddAnswer(string answerText, bool isCorrect)
        {
            Answers.Add(new Answer() { Text = answerText, IsCorrect = isCorrect });
        }

        public void Print(int num)
        {
            Console.WriteLine($"Question {num}. {Text}");
            for (int index = 0; index < Answers.Count; index++)
            {
                Answers[index].Print(index + 1);
            }
        }

        public bool IsAnswerCorrect(int num)
        {
            if (num >= Answers.Count) return false;

            return Answers[num - 1].IsCorrect;
        }
    }

    class Quizz
    {
        private List<Question> wrongQuestions = new List<Question>();
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public void Run()
        {
            wrongQuestions.Clear();

            Console.WriteLine($"Quizz - {Title}");
            for (int index = 0; index < Questions.Count; index++)
            {
                var question = Questions[index];
                question.Print(index + 1);
                string userInput = Console.ReadLine();
                if (!question.IsAnswerCorrect(int.Parse(userInput)))
                {
                    wrongQuestions.Add(question);
                }
            }

            double result = (Questions.Count - wrongQuestions.Count) / Questions.Count * 100.0;
            Console.WriteLine($"Your result: {result} %");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Quizz() { Title = "Simple Test" };
            test.Questions.Add(new Question()
            {
                Text = "WTF?",
                Answers = new List<Answer>() { new Answer() { Text = "Var1", IsCorrect = true }, new Answer() { Text = "Var2", IsCorrect = false} }
            });

            test.Run();
        }
    }
}
