using NUnit.Framework;

namespace MulTest
{
    public class Tests
    {
        [Test]
        public void TestSum()
        {
            int num1 = 5;
            int num2 = 15;

            var mul = Examples.Program.Mul(num1, num2);

            Assert.AreEqual(150, mul);
        }
    }
}