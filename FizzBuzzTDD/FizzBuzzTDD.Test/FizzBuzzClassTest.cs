using System;
using NUnit.Framework;

namespace FizzBuzzTDD.Test {
    [TestFixture]
    public class FizzBuzzTest {
        [Test]
        public void testFizzBuzzCalc_DivisibleByFive_ReturnFizz()
        {
            string s = TestMethodWithInput(20);

            Assert.That(s, Is.EqualTo("Fizz"));
        }

        [Test]
        public void testFizzBuzzCalc_ContainsAFive_ReturnFizz()
        {
            string s = TestMethodWithInput(5);

            Assert.That(s, Is.EqualTo("FizzFizz"));
        }

        [Test]
        public void testFizzBuzzCalc_DivisibleBySeven_ReturnBuzz()
        {
            string s = TestMethodWithInput(14);

            Assert.That(s, Is.EqualTo("Buzz"));
        }

        [Test]
        public void testFizzBuzzCalc_ContainsASeven_ReturnBuzz()
        {
            string s = TestMethodWithInput(7);

            Assert.That(s, Is.EqualTo("BuzzBuzz"));
        }

        [TestCase(20, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "FizzFizz")]
        [TestCase(46, ExpectedResult = "46")]
        [TestCase(35, ExpectedResult = "FizzFizzBuzz")]
        [TestCase(50, ExpectedResult = "FizzFizz")]
        [TestCase(55, ExpectedResult = "FizzFizz")]
        [TestCase(49, ExpectedResult = "Buzz")]
        public string testFizzBuzzCalc_RandomInputs_ReturnCorrectFizzBuzz(int input)
        {
            return TestMethodWithInput(input);
        }

        private string TestMethodWithInput(int input)
        {
            FizzBuzz FB = new FizzBuzz();
            return FB.FizzBuzzCalc(input);
        }
    }
}
