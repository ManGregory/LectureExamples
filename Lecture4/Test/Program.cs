using System;
namespace Lecture3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hemoglobin();
        }

        public static void Hemoglobin()
        {
            const double Percent = 0.2;
            const string High = "High"; 
            const string Low = "Low"; 
            const string PanicLow = "Panic Low"; 
            const string PanicHigh = "Panic High"; 
            const string Normal = "Normal"; 
            const string Female = "F"; 

            int age = Convert.ToInt32(Console.ReadLine()); 
            string sex = Console.ReadLine(); 
            int hemo = Convert.ToInt32(Console.ReadLine()); 

            double normalRangeFrom = 100.0; 
            double normalRangeTo = 140.0;
            if (age >= 13 && age <= 18) 
            { 
                normalRangeFrom = sex == Female ? 112.0 : 120.0; 
                normalRangeTo = sex == Female ? 152.0 : 160.0; 
            }
            else if (age >= 19 && age <= 65) 
            { 
                normalRangeFrom = sex == Female ? 120.0 : 130.0; 
                normalRangeTo = sex == Female ? 155.0 : 160.0; 
            }
            else if (age > 65)
            {
                normalRangeFrom = sex == Female ? 120.0 : 125.0; 
                normalRangeTo = sex == Female ? 157.0 : 165.0;
            }

            double lowHemo = normalRangeFrom - (normalRangeFrom * Percent); 
            double highHemo = normalRangeTo + (normalRangeTo * Percent);

            string result;
            if (hemo >= normalRangeFrom && hemo <= normalRangeTo) 
            { 
                result = Normal; 
            } 
            else if (hemo >= lowHemo && hemo < normalRangeFrom) 
            { 
                result = Low; 
            } 
            else if (hemo <= highHemo && hemo > normalRangeTo) 
            { 
                result = High; 
            } 
            else if (hemo < lowHemo) 
            { 
                result = PanicLow; 
            } 
            else 
            { 
                result = PanicHigh;
            }
            Console.WriteLine(result);
        }
    }
}