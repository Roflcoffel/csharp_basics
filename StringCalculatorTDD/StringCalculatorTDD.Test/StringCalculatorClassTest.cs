using System;
using NUnit.Framework;

namespace StringCalculatorTDD.Test {
    [TestFixture]
    public class StringCalculatorTest {
        [Test]
        public void Add_Empty_String_Test()
        {
            StringCalculator StringCalc = new StringCalculator();

            int zero = StringCalc.Add("");
            Assert.That(zero, Is.EqualTo(0));
        }

        [Test]
        public void Add_Two_Numbers_Comma_Seperated_Test()
        {
            StringCalculator StringCalc = new StringCalculator();

            int six = StringCalc.Add("2,4");
            Assert.That(six, Is.EqualTo(6));
        }

        [Test]
        public void Add_Single_Digit_Test()
        {
            StringCalculator StringCalc = new StringCalculator();

            int three = StringCalc.Add("3");
            Assert.That(three, Is.EqualTo(3));
        }

    }
}
