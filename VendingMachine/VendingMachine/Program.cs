using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Classes;

namespace VendingMachine {
    class Program {
        static Machine vm = new Machine();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            while(true)
            {
                Console.WriteLine($"Current Total Input: {vm}");

                DisplayInputMenu();

                Console.Clear();
            }
        }

        public static void DisplayInputMenu()
        {
            Console.WriteLine("###### Input Coin ######");
            Console.WriteLine("#      1    Kr         #");
            Console.WriteLine("#      5    Kr         #");
            Console.WriteLine("#      20   Kr         #");
            Console.WriteLine("#      50   Kr         #");
            Console.WriteLine("#      100  Kr         #");
            Console.WriteLine("#      500  Kr         #");
            Console.WriteLine("#      1000 Kr         #");
            Console.WriteLine("########################");

            Money money = new Money(Convert.ToInt32(Console.ReadLine()));

            money.Value = money.ConvertToValue();

            Console.WriteLine($"\n{money.Value} inputted");
            vm.AddMoney(money);
        }

        public static void DisplayStockMenu()
        {
            Console.WriteLine("-- Select Item --");
            vm.Stock.ForEach(
                item => Console.WriteLine($"{vm.Stock.IndexOf(item)}. Label: {item.Label} - {item.Prize}Kr")
            );

            int input = Convert.ToInt32(Console.ReadLine());

            if(vm.Stock[input] != null)
            {
                Console.WriteLine($"\n{vm.Stock[input].Label} added to cart");
                vm.Cart.Add(vm.Stock[input]);
            }
        }
    }
}
