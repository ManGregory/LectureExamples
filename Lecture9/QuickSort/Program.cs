using System;
using System.Diagnostics;

namespace QuickSort
{
	public class Program
	{
		static void Main(string[] args)
		{
			// генерируем массив случайных чисел
			Random rand = new Random();
			int[] arr = new int[10000000];
			for (int index = 0; index < arr.Length; index++)
			{
				arr[index] = rand.Next(1, 100000);
			}

			// создаем таймер
			Stopwatch stopwatch = new Stopwatch();

			// стартуем таймер
			stopwatch.Start();
			// выполняем сортировку
			QuickSort(arr, 0, arr.Length - 1);
			// останавливаем таймер
			stopwatch.Stop();

			// выводит кол-во миллисекунд затраченных на сортировку
			Console.WriteLine(stopwatch.ElapsedMilliseconds);

			// сбрасываем значения таймера
			stopwatch.Reset();

			Console.ReadKey();
		}

		public static void QuickSort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				// выбираем опорный элемент и делаем так чтобы слева от опорного были элементы которые меньше
				// а справа элементы которые больше
				int pivot = Partition(arr, low, high);
				// посел выполняем ту жу процедуру но уже для части массива слева от опорного
				QuickSort(arr, low, pivot - 1);
				// и части массива справа от опорного
				QuickSort(arr, pivot + 1, high);
			}
		}

		public static int Partition(int[] arr, int low, int high)
		{
			// выбор опорного элемента
			int pivot = arr[(low + high) / 2];

			// индекс элемента меньше опорного, начинаем с левого края массива
			int lowerIndex = low - 1;
			// индекс элемента больше опорного, начинаем с правого края массива
			int higherIndex = high + 1;
			while (true)
			{
				// ищем индекс элемента который будет слева от опорного, но больше опорного
				do
				{
					lowerIndex++;
				} while (arr[lowerIndex] < pivot);

				// ищем индекс элемента который будет справа от опорного, но меньше опорного
				do
				{
					higherIndex--;
				} while (arr[higherIndex] > pivot);

				// если индексы меньшего и большего пересеклись значит слева от опорного все элементы меньше, а справа больше
				// это то чего мы добивались
				// возвращаем индекс опорного элемента
				if (lowerIndex >= higherIndex) return higherIndex;

				// меняем местами элемент который больше и находится слева от опорного с тем который меньше опорного но находится справа
				int temp = arr[higherIndex];
				arr[higherIndex] = arr[lowerIndex];
				arr[lowerIndex] = temp;
			}
		}
	}
}