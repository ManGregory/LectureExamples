using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // arrange

            // action
            //var hello = Example1.Program.HelloWorld();
            // assert
            //Assert.AreEqual("Hello World", hello);
        }

        [Test]
        public void Test2()
        {
            // arrange

            // action
            var hello = Example1.Program.HelloWorld();
            // assert
            Assert.AreNotEqual("asdf", hello);
        }
    }
}