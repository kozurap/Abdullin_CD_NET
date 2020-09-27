using System;
using NUnit.Framework;
using ConsoleApplication1;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Sum_54Plus_2_56Returned()
        {
            Assert.AreEqual(56, Calculator.Calculate(54,2,"+"));
            }
        [Test]
        public void DivisionByZero_ExceptionReturned()
        {
            try
            {
                Calculator.Calculate(2, 0, "/");
            }
            catch
            {
                Assert.Pass();
            }
        }
        [Test]
        public void Division_51Divide_2_25_Plus_5Divide10_Returned()
        {
            Assert.AreEqual(25.5, Calculator.Calculate(51, 2, "/"));
        }
        [Test]
        public void InvalidInput_ExceptionReturned()
        {
            try
            {
                Calculator.Calculate(54, 2, "haha");
            }
            catch
            {
                Assert.Pass();
            }
        }
        [Test]
        public void Division_54Divide_2_27Returned()
        {
            Assert.AreEqual(27, Calculator.Calculate(54, 2, "/"));
        }
        [Test]
        public void Multiplication_54Multiply_2_108Returned()
        {
            Assert.AreEqual(108, Calculator.Calculate(54, 2, "*"));
        }
        [Test]
        public void Substruct_54Minus_2_52Returned()
        {
            Assert.AreEqual(52, Calculator.Calculate(54,2,"-"));
        }
    }
}