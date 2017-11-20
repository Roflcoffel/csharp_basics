using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VendingMachine.Classes;

namespace VendingMachine {
    class Program {
        static Machine vm = new Machine();
        static User user = new User();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            
            MainMenu();
        }

        public static void DisplayPersonalItems()
        {
            Console.WriteLine("--Items in the bag--");

            user.Stuff.ForEach(
                x => Console.WriteLine(x)
            );

            Console.WriteLine("--Money in hand--");

            user.PocketMoney.ForEach(
                x => Console.WriteLine(x)
            );

            Console.ReadLine();
        }

        public static void UseItem()
        {
            Console.WriteLine("--Current items in the bag--");

            int i = 0;

            foreach (var product in user.Stuff)
            {
                Console.WriteLine($"{i}. {product}");
                i++;
            }

            Console.WriteLine("Select an item to use");

            string input = Console.ReadLine();

            Regex pattern = new Regex("[0-9]+");

            if(pattern.IsMatch(input))
            {
                Console.WriteLine(user.Stuff[Convert.ToInt32(input)].Use());
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public static void ReturnChange()
        {
            vm.ReturnChange(user);

            Console.WriteLine("Change Returned!");

            user.PocketMoney.ForEach(
                x => Console.WriteLine(x)
            );

            Console.ReadLine();
        }

        public static void DisplayInputMenu()
        {
            Console.WriteLine($"Current Money: {vm}");
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

            Regex pattern = new Regex("[0-9]+");

            if(pattern.IsMatch(input))
            {
                //Try Catch här
                Money money = new Money(Convert.ToInt32(input));
                Console.WriteLine($"\n{money} inputted\n");

                vm.AddMoney(money);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public static void DisplayStockMenu()
        {
            Console.Clear();
            Console.WriteLine($"Current Money: {vm}");
            Console.WriteLine("-- Select Item To Buy --");
            Console.WriteLine("\nEnter 'q' to return to menu");

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

            Regex pattern = new Regex("[0-9]+");

            if (pattern.IsMatch(input))
            {
                if (vm.Stock[i] != null)
                {
                    if (vm.Buy(vm.Stock[i], user))
                    {
                        Console.WriteLine($"\n{vm.Stock[i].Label} bought");
                    }
                    else
                    {
                        Console.WriteLine("Input more money");
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.ReadLine();
            }
        }

        public static void MainMenu()
        {
           
            Console.WriteLine($"Current Money: {vm}");
            Console.WriteLine("1. Input Coins");
            Console.WriteLine("2. Display Products");
            Console.WriteLine("3. Return Change");
            Console.WriteLine();
            Console.WriteLine("4. Display Bought Items / Money");
            Console.WriteLine("5. Use Item");
            Console.WriteLine("6. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    while(true)
                    {
                        DisplayInputMenu();
                    }
                case "2":
                    Console.Clear();
                    while (true)
                    {
                        DisplayStockMenu();
                    }
                case "3":
                    Console.Clear();
                    ReturnChange();
                    MainMenu();
                    break;
                case "4":
                    Console.Clear();
                    DisplayPersonalItems();
                    MainMenu();
                    break;
                case "5":
                    Console.Clear();
                    UseItem();
                    MainMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.Clear();
            MainMenu();
        }
    }
}
