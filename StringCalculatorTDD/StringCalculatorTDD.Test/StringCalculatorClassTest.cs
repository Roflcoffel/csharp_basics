using System;
using NUnit.Framework;
using StringCalculatorTDD;

namespace StringCalculatorTDD.Test {
    [TestFixture]
    public class StringCalculatorTest {
        [Test]
        public void testAdd_IsStringEmpty_ReturnZero()
        {
            StringCalculator StringCalc = new StringCalculator();

            int zero = StringCalc.Add("");
            Assert.That(zero, Is.EqualTo(0));
        }

        [Test]
        public void testAdd_TwoNumbersCommaSeperated_ReturnSum()
        {
            StringCalculator StringCalc = new StringCalculator();

            int six = StringCalc.Add("2,4");
            Assert.That(six, Is.EqualTo(6));
        }

        [Test]
        public void testAdd_SingleNumber_ReturnItself()
        {
            StringCalculator StringCalc = new StringCalculator();

            int three = StringCalc.Add("3");
            Assert.That(three, Is.EqualTo(3));
        }

        [TestCase("1,5,3,2", ExpectedResult = 11)]
        [TestCase("8,2,2", ExpectedResult = 12)]
        [TestCase("", ExpectedResult = 0)]
        public int testAdd_UnkownAmountOfNumbers_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [TestCase("1\n2,5", ExpectedResult = 8)]
        public int testAdd_CarriageDelimeter_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [TestCase(";\n5;5", ExpectedResult = 10)]
        public int testAdd_ChangeDefaultDelimter_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [Test]
        public void testAdd_NegativeNumbers_ThrowsException()
        {
            StringCalculator StringCalc = new StringCalculator();

            Assert.Throws<NegativeNumberException>(() => StringCalc.Add("-1,-1,-1"));
;       }

        [TestCase("1002,2,1", ExpectedResult = 3)]
        [TestCase("1000,1", ExpectedResult = 1001)]
        [TestCase("999,2,1", ExpectedResult = 1002)]
        public int testAdd_LargerThanThousand_ThousandDiscardedInSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [TestCase("[;;;;;]\n10;;;;;10;10;;10", ExpectedResult = 40)]
        [TestCase("[%]\n5%%%5", ExpectedResult = 10)]
        public int testAdd_AnyNumberOfDelimiters_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [TestCase("[*][%]\n10**5%5", ExpectedResult = 20)]
        [TestCase("[;][*]\n10;;;10*5", ExpectedResult = 25)]
        public int testAdd_TwoDiffrentDelimiters_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        [TestCase("[***][%%%%]\n10**5%5", ExpectedResult = 20)]
        [TestCase("[;;;;][*]\n10;;;10*5", ExpectedResult = 25)]
        public int testAdd_TwoDiffrentDelimitersAnySize_ReturnSum(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }

        //Setup and Shortcut Method
        private int StringAddMethod(string input)
        {
            StringCalculator StringCalc = new StringCalculator();

            return StringCalc.Add(input);
        }
    }
}
