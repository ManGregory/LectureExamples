using System;

namespace VariableAreas
{
    class Program
    {
        static void Main(string[] args)
        {
            // область видимости метода, здесь есть доступ к переменной a
            bool a = false;
            { // здесь началась вложенная область видимости                
                int b = 20;
                // вложенная область видимости, здесь есть доступ к переменным a, b
                Console.WriteLine(b);
            } // здесь закончилась вложенная область видимости
            //Console.WriteLine(b);
            Console.WriteLine(a);
        }
    }
}
