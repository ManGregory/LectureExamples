using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortingTests
{
    class BubbleSortTests
    {
        [Test]
        public void TestBubbleSortNormal()
        {
            int[] arr = { 3, 5, 8, 1, 3, 5, 9 };

            BubbleSort.Program.BubbleSort(arr);

            Assert.AreEqual(new int[] { 1, 3, 3, 5, 5, 8, 9 }, arr);
        }
    }
}
