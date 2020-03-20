using System;
using System.Collections.Generic;

namespace Example1
{
    /*
     Создать класс для описания сотрудника предприятия. Нужно использовать наследование от класса человека и добавить следующие характеристики:
        Должность
        Зарплата
        Список задач над которым работает сотрудник (список строк)
     Добавить в класс сотрудника необходимые конструкторы и метод для печати должности и зарплаты
     Добавить еще два класса наследника от сотрудника: Рабочий и Менеджер. 
     Для менеджера добавить список подчиненных и возможность раздавать задачи конкретному подчиненному.
     */
    /*
     Используя подобную иерархию классов, мы можем смоделировать работу целой компании
     Конечно же будет необходимо добавить дополнительные характеристики и поведение в объекты.
     Но в рамках этой задачи мы рассмотрели как создать иерархию классов с помощью наследования и использовать её в коде
     */


    // Базовый класс для описания человека
    class Person
    {
        // имя человека
        public string FirstName { get; set; }
        // фамилия человека
        public string LastName { get; set; }
    }

    // класс для описания сотрудника предприятия
    // он наследуется от класса человека
    // двоеточие используется для указания базового класса
    // после него идет название базового класса
    // Employee - класс-потомок или дочерний класс
    // Person - класс-родитель или базовый класс
    class Employee : Person
    {
        // должность
        public string Occupation { get; set; }
        // ЗП
        public decimal Salary { get; set; }
        // Список задач сотрудника
        public List<string> Tasks { get; set; }

        // конструктор без аргументов или конструктор по умолчанию
        public Employee()
        {
            Tasks = new List<string>();
        }

        // конструктор с параметрами
        public Employee(string occupation, decimal salary)
        {
            Tasks = new List<string>();
            Occupation = occupation;
            Salary = salary;
        }

        // печать должности
        public void PrintOccupation()
        {
            Console.WriteLine($"Occupation is {Occupation}");
        }

        // печать зарплаты
        public void PrintSalary()
        {
            Console.WriteLine($"Salary = {Salary}");
        }

        public void PrintTasks()
        {
            Console.WriteLine($"This is list of taskf for {FirstName} {LastName}: ");
            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    // работник компании
    class Worker : Employee
    {
        public void DoWork()
        {
            Console.WriteLine("I did some work");
        }
    }

    // менеджер в компании
    // класс Manager наследуется от класса Employee
    class Manager : Employee
    {
        // список подчиненных
        public List<Employee> Subordinates { get; set; }

        // конструктор по умолчанию
        public Manager()
        {
            // инициализация списка подчиненных
            Subordinates = new List<Employee>();
        }

        public void AssignTask(string task, Employee employee)
        {
            // проверка является ли employee подчиненным менеджера
            bool hasInSubordiantes = false;
            foreach (var subordinate in Subordinates)
            {
                // проверяем по совпадению имени и фамилии
                if (subordinate.FirstName == employee.FirstName && subordinate.LastName == employee.LastName)
                {
                    hasInSubordiantes = true;
                }
            }

            // если является
            if (hasInSubordiantes)
            {
                // то добавляем этому подчиненному задачу
                employee.Tasks.Add(task);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создаем менеджера
            var manager = new Manager
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Occupation = "CEO",
                Salary = Decimal.MaxValue
            };

            // создаем работника
            var worker = new Worker
            {
                FirstName = "Petr",
                LastName = "Petrov",
                Occupation = "Worker",
                Salary = 10000
            };
            // добавляем подчиненного менеджеру
            manager.Subordinates.Add(worker);
            // менеджер дает таску своему подчиненному
            manager.AssignTask("Do some work", worker);

            // печатаем задачи менеджера (у него их нет, все раздал подчинненым)
            manager.PrintTasks();
            // печатаем задачи подчиненного
            worker.PrintTasks();

            // создаем еще одного рабочего
            var worker2 = new Worker
            {
                FirstName = "Vasya"
            };
            // пытаемся выдать таску worker2, но не может, т.к. в методе AssignTask есть проверка
            manager.AssignTask("Do somw work", worker2); // ?
            // печатаем таски worker2 (у него их тоже нет)
            worker2.PrintTasks();
        }
    }
}
