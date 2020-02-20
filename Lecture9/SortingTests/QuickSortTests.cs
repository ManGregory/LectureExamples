using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortingTests
{
    class QuickSortTests
    {
        [Test]
        public void TestQuickSortNormal()
        {
            int[] arr = { 3, 5, 8, 1, 3, 5, 9 };

            QuickSort.Program.QuickSort(arr, 0, arr.Length - 1);

            Assert.AreEqual(new int[] { 1, 3, 3, 5, 5, 8, 9 }, arr);
        }
    }
}
