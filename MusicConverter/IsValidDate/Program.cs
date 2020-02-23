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
            Console.WriteLine(IsValidDate(""));
        }

        /// <summary>
        /// Функция определяет валидность введенной пользователем даты
        /// </summary>
        /// <param name="date">Дата в виде строке</param>
        /// <returns>True - если дата валидна, иначе false</returns>
        public static bool IsValidDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date)) return false;

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

            return days <= maxDaysInMonth;
        }
    }
}
