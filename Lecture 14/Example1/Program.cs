using System;
using System.Collections.Generic;

namespace Example1
{
    // статический класс может содержать только статические методы и поля
    static class Physics
    {
        // статические поля
        public static double PlanckLength = 1.616E-35;
        public static double PlanckMass = 2.176E-8;

        // нельзя объявлять экзмеплярные поля в статическом классе
        // private double mass;

        // статический метод
        public static double CalculateSpeed(double distance, double time)
        {
            return distance / time;
        }
    }

    class Program
    {
        public static void Swap(ref int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        static void Main(string[] args)
        {
        }
    }
}
