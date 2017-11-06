using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Classes;

namespace VendingMachine {
    class Program {
        static Machine vm = new Machine();
        static User user = new User();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            while(true)
            {
                MainMenu();
            }
        }

        public static void DisplayInputMenu()
        {
            Console.WriteLine($"Current Total Input: {vm}");
            Console.WriteLine("###### Input Coin ######");
            Console.WriteLine("#      1    Kr         #");
            Console.WriteLine("#      5    Kr         #");
            Console.WriteLine("#      20   Kr         #");
            Console.WriteLine("#      50   Kr         #");
            Console.WriteLine("#      100  Kr         #");
            Console.WriteLine("#      500  Kr         #");
            Console.WriteLine("#      1000 Kr         #");
            Console.WriteLine("########################");
            Console.WriteLine("\nEnter 'q' to return to menu");

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "q":
                    MainMenu();
                    break;
                default:
                    break;
            }

            Money money = new Money(Convert.ToInt32(input));
            Console.WriteLine($"\n{money} inputted");

            vm.AddMoney(money);

        }

        public static void DisplayStockMenu()
        {
            Console.WriteLine("-- Select Item To Buy --");
            vm.Stock.ForEach(
                item => Console.WriteLine($"{vm.Stock.IndexOf(item)}. Label: {item.Label} - {item.Prize}Kr")
            );

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "q":
                    MainMenu();
                    break;
                default:
                    break;
            }

            int i = Convert.ToInt32(input);

            if (vm.Stock[i] != null)
            {
                Console.WriteLine(vm.Buy(vm.Stock[i], user));
                Console.WriteLine($"\n{vm.Stock[i].Label} bought");
                
                Console.ReadKey();
            }

            Console.Clear();
        }

        public static void MainMenu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine($"Current Total Input: {vm}");
                Console.WriteLine("1. Input Coins");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        while(true)
                        {
                            DisplayInputMenu();
                        }
                    case "2":
                        while(true)
                        {
                            DisplayStockMenu();
                        }
                    case "3":
                        run = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }   
        }
    }
}
