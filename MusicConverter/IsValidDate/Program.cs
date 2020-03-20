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

        public static bool IsValidDate(string date)
        {
            var dateArr = date.Split(".");
            foreach (string num in dateArr)
            {
                int number;
                bool correctDate = int.TryParse(num, out number);
                if (!correctDate)
                {
                    return false;
                }
            }

            // разделяем дату на отдельные числа
            var nums = date.Split(".", StringSplitOptions.RemoveEmptyEntries);
            if (nums.Length < 3 || nums.Length > 3)
            {
                return false;
            }
            int day = int.Parse(nums[0]);
            int month = int.Parse(nums[1]);
            int year = int.Parse(nums[2]);

            if (IsRightFormat(nums))
            {
                if (year >= 1 && day > 0 && day <= DaysInMonth(month, year) && month > 0 && month <= 12 && date != string.Empty)
                {
                    return true;
                }
            }

            return false;
        }

        //метод проверяет высокостный ои год
        static bool IsLeapYear(int year)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            return false;
        }


        // метод возвращает количество дней в месяце
        static int DaysInMonth(int month, int year)
        {
            int[] days31 = new int[] { 01, 03, 05, 07, 08, 10, 12 };
            for (int numOfMonth = 0; numOfMonth < days31.Length; numOfMonth++)
            {
                if (month == days31[numOfMonth])
                {
                    return 31;
                }
            }
            if (IsLeapYear(year) && month == 02)
            {
                return 29;
            }
            else if (!IsLeapYear(year) && month == 02)
            {
                return 28;
            }
            return 30;
        }

        // метод проверяет формат даты
        static bool IsRightFormat(string[] nums)
        {
            if (nums[0].Length == 2 && nums[1].Length == 2 && nums[2].Length == 4)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Функция определяет валидность введенной пользователем даты
        /// </summary>
        /// <param name="date">Дата в виде строке</param>
        /// <returns>True - если дата валидна, иначе false</returns>
        /*public static bool IsValidDate(string date)
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
        }*/
    }
}
