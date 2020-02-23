using NUnit.Framework;

namespace TestIsValidDate
{
    public class IsValidDateTests
    {
        string date1 = "";
        string date2 = "10.10.2019";
        string date3 = "10/10/2019";
        string date4 = "31.09.2019";
        string date5 = "99.99.9999";
        string date6 = "10.13.9999";
        string date7 = "28.02.2019";
        string date8 = "29.02.2019";
        string date9 = "29.02.2020";
        string date10 = "29.02.1900";
        string date11 = "aa.bb.cccc";
        string date12 = "..";
        string date13 = "31.01.2018";
        string date14 = "30.04.2018";
        string date15 = "-1.04.2018";
        string date16 = "00.04.2018";

        [Test]
        public void IsValidDate1Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date1);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate2Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date2);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate3Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date3);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate4Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date4);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate5Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date5);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate6Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date6);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate7Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date7);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate8Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date8);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate9Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date9);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate10Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date10);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate11Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date11);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate12Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date12);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate13Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date13);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate14Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date14);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate15Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date15);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidDate16Test()
        {
            bool result = IsValidDate.Program.IsValidDate(date16);

            Assert.IsFalse(result);
        }
    }
}