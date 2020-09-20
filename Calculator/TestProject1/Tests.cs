using System;
using NUnit.Framework;
using ConsoleApplication1;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Calculator_Operators_Test()
        {
            var calc1 = new Calculator(54, 2, "+");
            var calc2 = new Calculator(54, 2, "-");
            var calc3 = new Calculator(54, 2, "*");
            var calc4 = new Calculator(54, 2, "/");
            var calc5 = new Calculator(54, 2, "haha");
            Assert.AreEqual(56, calc1.Calculate());
            Assert.AreEqual(52, calc2.Calculate());
            Assert.AreEqual(108, calc3.Calculate());
            Assert.AreEqual(27, calc4.Calculate());
            try
            {
                calc5.Calculate();
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}