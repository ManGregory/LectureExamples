using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /*Console.WriteLine("Введите N");
            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите M");
            int m = Int32.Parse(Console.ReadLine());

            int sum = 0;
            if (n < m)
            {                
                for (int i = n; i <= m; i++)
                {
                    bool b = i > 1;
                    for (int j = 2; j <= i  / 2; j++)
                    {
                        if (i % j == 0)
                        {

                            b = false;
                            break;
                        }
                    }
                    if (b)
                        sum += i;
                    //Console.WriteLine(sum);
                }
            }

            Console.WriteLine(sum);*/

            int low = 0;
            int high = 1000;
            string userInput = "";

            do
            {
                int num = (high - low) / 2 + low;
                Console.WriteLine("Ваше число: {0}", num);
                Console.WriteLine("Введите > если число больше, < если меньше, или = если угадал");
                userInput = Console.ReadLine();
                if (userInput == ">")
                {
                    low = num;
                }
                else if (userInput == "<")
                {
                    high = num;
                }
            } while (low < high && userInput != "=");

            Console.ReadKey();
        }
    }
}
