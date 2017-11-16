using System;
using NUnit;
using VendingMachine.Classes;
using NUnit.Framework;
using System.Collections.Generic;

namespace VendingMachine.Test {
    [TestFixture]
    public class MachineTest {

        [TestCase(100, ExpectedResult = true)]
        [TestCase(50, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        public bool Buy_Completed_Test(int inputMoney)
        {
            //Buy Takes:
            //IPurchable and user
            Machine vm = new Machine();

            //Setup
            vm.AddMoney(new Money(inputMoney));
            Snack kex = new Snack("Kex", new Money(1));
            User user = new User();

            //Run
            return vm.Buy(kex, user);
        }

        [TestCase(100, ExpectedResult = false)]
        [TestCase(50, ExpectedResult = false)]
        [TestCase(20, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = false)]
        public bool Buy_Failed_Test(int inputMoney)
        {
            Machine vm = new Machine();

            //Setup
            vm.AddMoney(new Money(inputMoney));
            Snack kex = new Snack("Kex", new Money(1000));
            User user = new User();

            //Run
            return vm.Buy(kex, user);
        }

        [Test]
        public void Change_Is_Returned_Test()
        {
            Machine vm = new Machine();
            User user = new User();

            vm.AddMoney(new Money(50));
            vm.AddMoney(new Money(100));
            vm.AddMoney(new Money(5));
            vm.AddMoney(new Money(20));
            vm.AddMoney(new Money(1));
            vm.AddMoney(new Money(500));
            vm.AddMoney(new Money(1000));
            vm.AddMoney(new Money(50));
            vm.AddMoney(new Money(20));

            List<Money> expected = vm.Pool;
            vm.ReturnChange(user);

            CollectionAssert.AreEqual(expected, user.PocketMoney);

        }

    }
}
