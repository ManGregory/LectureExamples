using System;
using System.Linq;

namespace IsValidDate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(IsValidDate("22.10.2014"));
            //Console.WriteLine(IsValidDate("33.10.2014"));
            Console.WriteLine(IsValidDate("29.02.2020"));
            Console.WriteLine(IsValidDate("29.02.1900"));
        }

        /// <summary>
        /// Функция определяет валидность введенной пользователем даты
        /// </summary>
        /// <param name="date">Дата в виде строке</param>
        /// <returns>True - если дата валидна, иначе false</returns>
        public static bool IsValidDate(string date)
        {
            /*if (string.IsNullOrWhiteSpace(date)) return false;

            var parts = date.Split(".", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3) return false;

            if (parts[0].Length != 2 || parts[1].Length != 2 || parts[2].Length != 4) return false;

            bool allDigits = int.TryParse(parts[0], out int days) & 
                int.TryParse(parts[1], out int months) &
                int.TryParse(parts[2], out int years);

            if (!allDigits) return false;
            if (days > 31 || days <= 0 || months > 12 || months <= 0) return false;

            bool isLeapYear = years % 4 == 0 && years % 100 != 0 || years % 400 == 0;
            int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int maxDaysInMonth = daysInMonths[months - 1] + (isLeapYear && months == 2 ? 1 : 0);

            return days <= maxDaysInMonth;*/

            if (date.IndexOf(".") != 2 && date.LastIndexOf(".") != 5)
            {
                return false;
            }

            string[] dayMonthYear = date.Split('.', StringSplitOptions.RemoveEmptyEntries);

            int day, month, year;

            bool validDay = int.TryParse(dayMonthYear[0], out day);
            bool validMonth = int.TryParse(dayMonthYear[1], out month);
            bool validYear = int.TryParse(dayMonthYear[2], out year);

            Console.WriteLine(year);

            if (!(validDay && validMonth))
            {
                return false;
            }

            bool daysInMonth31 = month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12;
            bool daysInMonth30 = month == 4 || month == 6 || month == 9 || month == 11;
            bool isYearLeap = (year % 4 == 0) || (year % 400 == 0 && year % 100 != 0);


            if (daysInMonth31 && 1 <= day && day <= 31)
            {
                return true;
            }
            else if (daysInMonth30 && 1 <= day && day <= 30)
            {
                return true;
            }
            else if (isYearLeap && 1 <= day && day <= 29 && month == 2)
            {
                return true;
            }
            else if (month == 2 && 1 <= day && day <= 28)
            {
                return true;
            }

            return false;
        }
    }
}
