using System;
using System.Collections.Generic;

namespace Example1
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
    }

    class Worker : Employee
    {
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
        }

        public void AssignTask(string task, Employee subordinate)
        {
            if (!Subordinates.Contains(subordinate))
            {
                return;
            }

            subordinate.AddTask(task);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager()
            {
                FirstName = "Ivan",
                BirthDate = DateTime.Now,
                Position = "Big boss",
                Salary = decimal.MaxValue
            };
            var subordinate = new Worker()
            {
                FirstName = "Andrey",
                Position = "Janitor",
                Salary = 1000m
            };

            manager.AddSubordinate(subordinate);
            manager.AssignTask("Clean floor", subordinate);
        }
    }
}
