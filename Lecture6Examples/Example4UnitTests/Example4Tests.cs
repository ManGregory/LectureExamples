using NUnit.Framework;

namespace Example4UnitTests
{
    public class Example4Tests
    {
        [Test]
        public void TestArraySumForEven()
        {
            // arrange
            int[] testArr = { 11, 10, 20, 30, 21 };

            // action
            int sum = Example4.Program.ArraySum(testArr, true);

            // assert
            Assert.AreEqual(sum, 60);
        }

        [Test]
        public void TestArraySumForOdd()
        {
            // arrange
            int[] testArr = { 10, 7, 5, 3, 21, 20 };

            // action
            int sum = Example4.Program.ArraySum(testArr, false);

            // assert
            Assert.AreEqual(sum, 36);
        }

        [Test]
        public void TestArraySumForEmptyArray()
        {
            // arrange
            int[] testArr = { };

            // action
            int sum = Example4.Program.ArraySum(testArr, true);

            // assert
            Assert.AreEqual(sum, 0);
        }
    }
}