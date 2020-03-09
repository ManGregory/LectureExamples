using System;
using System.Collections.Generic;

namespace CompanySimple
{
    public enum Sex
    {
        Male,
        Female
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    class Employee : Person
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public Manager Manager { get; set; }
        protected List<string> Tasks { get; set; }

        public Employee()
        {
            Tasks = new List<string>();
        }

        public void AddTask(string task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(string task)
        {
            Tasks.Remove(task);
        }
    }

    class Worker : Employee
    {
        public void CompleteTask(string task)
        {
            Console.WriteLine($"{Position} {FirstName} выполнил задачу: '{task}'");
            Manager.NotifyAboutCompletion(this, task);
        }
    }

    class Manager : Employee
    {
        private List<Employee> Subordinates { get; set; }

        public Manager()
        {
            Subordinates = new List<Employee>();
        }

        public void AddSubordinate(Employee subordinate)
        {
            Subordinates.Add(subordinate);
            subordinate.Manager = this;
        }

        public void AssignTask(string task, Employee subordinate)
        {
            if (!Subordinates.Contains(subordinate))
            {
                return;
            }

            subordinate.AddTask(task);
            Console.WriteLine($"Подчиненный {subordinate.FirstName} должен выполнить задачу: '{task}'");
        }

        public void NotifyAboutCompletion(Employee subordinate, string task)
        {
            if (!Subordinates.Contains(subordinate))
            {
                return;
            }
            Console.WriteLine($"{subordinate.FirstName} сообщил менеджеру: {FirstName} что закончил задачу");
            Console.WriteLine($"{subordinate.Position} {subordinate.FirstName} выполнил задачу '{task}'");

            subordinate.RemoveTask(task);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Manager() { FirstName = "Иван", Position = "Директор", Salary = Decimal.MaxValue };
            var janitor = new Worker() { FirstName = "Вася", Position = "Клининг менеджер", Salary = 1000 };
            var accountant = new Worker() { FirstName = "Алиса", Position = "Бухгалтер", Salary = 5000 };

            director.AddSubordinate(janitor);
            director.AddSubordinate(accountant);

            string task = "Помыть пол";
            director.AssignTask(task, janitor);

            janitor.CompleteTask(task);

            string accTask = "Подготовить месячный отчет";
            director.AssignTask(accTask, accountant);

            accountant.CompleteTask(accTask);

            Console.ReadKey();
        }
    }
}