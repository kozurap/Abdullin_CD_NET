using Microsoft.VisualStudio.TestTools.UnitTesting;
using CD_NET_HW1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calc1 = new Calculator(54, 2, "+");
            var calc2 = new Calculator(54, 2, "-");
            var calc3 = new Calculator(54, 2, "*");
            var calc4 = new Calculator(54, 2, "/");
            Assert.AreEqual(56, calc1.Calculate());
            Assert.AreEqual(52, calc2.Calculate());
            Assert.AreEqual(108, calc3.Calculate());
            Assert.AreEqual(27, calc4.Calculate());
        }
    }
}
