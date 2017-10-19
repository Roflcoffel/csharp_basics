using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator {
    class Program {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--BasicCalculator--");
            
            MenuSelect();
            
        }

        private static void MenuSelect()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1. Addition\n2. Subtraction\n3. Division\n4. Multiplication\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Select Mode: ");

                int input = Convert.ToInt32(Console.ReadLine());
                
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Addition Selected\n"); 
                        Addition();
                        break;
                    case 2:
                        Console.WriteLine("Subtraction Selected");
                        //Subtraction(input);
                        break;
                    case 3:
                        Console.WriteLine("Division Selected");
                        //Division(input);
                        break;
                    case 4:
                        Console.WriteLine("Multiplication Selected");
                        //Multiplication(input);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Addition()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("= -- Show result\n" + 
                "clear -- Clear input list\n" + 
                "q -- Return to menu\n" + 
                "print -- Prints the formula\n\nEnter a number to be summed: ");
            Console.ForegroundColor = ConsoleColor.White;

            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("-> ");
                string input = Console.ReadLine();

                bool isNumeric = Regex.IsMatch(input, @"^\d+$");

                if (input == "=")
                {
                    Console.WriteLine("= " + Add(numbers));
                }
                else if (input == "q")
                {
                    MenuSelect();
                }
                else if (input == "print")
                {
                    Console.Write("-> ");
                    numbers.ForEach(n =>
                    {
                        if (n == numbers.Last())
                        {
                            Console.Write(n + "\n");
                        }
                        else
                        {
                            Console.Write(n + " + ");
                        }
                    });
                }
                else if (input == "clear")
                {
                    numbers = new List<int>();
                }
                else if (isNumeric)
                {
                    numbers.Add(Convert.ToInt32(input));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input must be a number or command!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            
        }

        private static void CommandSelect()
        {
            
        }

        private static int Add(List<int> num)
        {
            return num.Sum();
        }
       
        private static int Sub(List<int> num)
        {
            int dif = 0;
            num.ForEach(n => dif -= n);
            return dif;
        }

        private static double Div(int num1, int num2)
        {
            return num1 / num2;
        }

        private static int Mul(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
