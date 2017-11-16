using System;
using NUnit.Framework;
using VendingMachine.Classes;

namespace VendingMachine.Test.Classes {
    [TestFixture]
    public class ProductTest {

        [TestCase(new int[] {20, 20, 5, 5, 5}, 50, ExpectedResult = 5)]
        [TestCase(new int[] {1, 1, 1, 1, 1, 1}, 5, ExpectedResult = 1)]
        [TestCase(new int[] {500, 5}, 100, ExpectedResult = 405)]
        [TestCase(new int[] {1000, 1, 1, 1, 1}, 5, ExpectedResult = 999)]
        public int Correct_Exchange_In_ChangeMethod_Test(int[] inputMoney, int costMoney)
        {
            //Change Method Require:
            //List<Money> and User;
            Machine vm = new Machine();

            //Setup
            for (int i = 0; i < inputMoney.Length; i++)
            {
                vm.AddMoney(new Money(inputMoney[i]));
            }
            Snack kex = new Snack("Kexchoklad", new Money(costMoney));
            User user = new User();

            //Run Method
            kex.Purchase(vm.Pool, user);

            return Convert.ToInt32(vm.ToString());
        }

        [TestCase("Kex", ExpectedResult = "Kex")]
        [TestCase("Macka", ExpectedResult = "Macka")]
        [TestCase("Matlåda", ExpectedResult = "Matlåda")]
        public string Product_Is_Delivered_Test(string name)
        {
            Machine vm = new Machine();

            Product item = new Product(name, new Money(5));
            vm.AddMoney(new Money(5));
            User user = new User();

            //Run Method
            item.Purchase(vm.Pool, user);

            return user.Stuff[0].Label;
        }
    }
}
