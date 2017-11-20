using System;
using NUnit.Framework;

namespace FizzBuzzTDD.Test {
    [TestFixture]
    public class FizzBuzzTest {
        [Test]
        public void FizzBuzzCalc_Positive_Integer_Test()
        {
            FizzBuzz FB = new FizzBuzz();
            string s = FB.FizzBuzzCalc(5);

            Assert.That(s, Is.EqualTo("Fizz Fizz "));
        }
    }
}
