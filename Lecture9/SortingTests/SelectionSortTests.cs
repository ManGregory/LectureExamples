using NUnit.Framework;

namespace SortingTests
{
    public class SelectionSortTests
    {
        [Test]
        public void TestSelectionSortNormal()
        {
            int[] arr = { 3, 5, 8, 1, 3, 5, 9 };

            SelectionSort.Program.SelectionSort(arr);

            Assert.AreEqual(new int[] { 1, 3, 3, 5, 5, 8, 9 }, arr);
        }
    }
}