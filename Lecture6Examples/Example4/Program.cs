using System;
using System.Linq;

namespace Example4
{
    public class Program
    {
        /*
         Написать функцию для расчета суммы элементов массива. 
         После добавить в функцию параметр, 
         который будет определять рассчитывать сумму для четных или нечетных значений (параметр типа bool, true - четные, false - нечетные)
         */
        static void Main(string[] args)
        {
            // проверяем для четных
            Console.WriteLine(ArraySum(new []{ 10, 20, 35}, true)); // sum = 30
            // проверяем для нечетных
            Console.WriteLine(ArraySum(new []{ 11, 23, 40}, false)); // sum = 34
        }

        // функция для расчета суммы
        // обратитие внимание что для нее есть несколько тестов в проекте Example4UnitTests
        public static int ArraySum(int[] arr, bool forEven)
        {
            // переменная для накапливания суммы
            int sum = 0;

            // цикл по всем элементам массивам начиная с нулевого индекса и заканчивая длина массива - 1
            for (int index = 0; index < arr.Length; index++)
            {
                // переменная чтобы определить нужно ли элемент учитывать в сумме
                // в зависимости от переданного параметра forEven и самого значения элемента
                bool shouldCountSum = (forEven && arr[index] % 2 == 0) || (!forEven && arr[index] % 2 != 0);
                // накапливаем сумму в переменной
                sum += shouldCountSum ? arr[index] : 0;
            }

            // возвращаем результат
            return sum;
        }

        // как сделать тоже самое но немного короче
        public static int SimpleArraySum(int[] arr, bool forEven)
        {
            return arr
                .Where(elem => (forEven && elem % 2 == 0) || (!forEven && elem % 2 != 0)) // здесь фильтруем массив по условию
                .Sum(); // а здесь суммируем то что отфильтровали
        }
    }
}
