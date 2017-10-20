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
                        NameDisplay(input);
                        CommandSelect(input);
                        break;
                    case 2:
                        NameDisplay(input);
                        CommandSelect(input);
                        break;
                    case 3:
                        NameDisplay(input);
                        CommandSelect(input);
                        break;
                    case 4:
                        NameDisplay(input);
                        CommandSelect(input);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void NameDisplay(int input)
        {
            string s = (input == 1) ? "Addition" : (input == 2) ? "Subtraction" : (input == 3) ? "Division" : "Multiplication";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{s} Selected");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ControlDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=     -- Show result\n" +
                "clear -- Clear input list\n" +
                "q     -- Return to menu\n" +
                "print -- Prints the formula\n\nEnter numbers: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void CommandSelect(int numInput)
        {
            ControlDisplay();

            List<int> numbers = new List<int>();
            

            while (true)
            {
                Console.Write("-> ");
                string input = Console.ReadLine();
                

                bool isNumeric = Regex.IsMatch(input, @"^\d+$");

                if (isNumeric)
                {
                    if(numInput == 4 || numInput == 3)
                    {
                        if(numbers.Count != 2)
                        {
                            numbers.Add(Convert.ToInt32(input));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("List Full!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        numbers.Add(Convert.ToInt32(input));
                    }
                    
                }
                else
                {
                    if (input == "clear")
                    {
                        numbers = new List<int>();
                    }
                    else if (input == "q")
                    {
                        MenuSelect();
                    }

                    if (numbers.Any())
                    {
                        if (input == "=")
                        {
                            switch (numInput)
                            {
                                case 1:
                                    Console.WriteLine("= " + Add(numbers));
                                    break;
                                case 2:
                                    Console.WriteLine("= " + Sub(numbers));
                                    break;
                                case 3:
                                    Console.WriteLine("= " + Div(numbers));
                                    break;
                                case 4:
                                    Console.WriteLine("= " + Mul(numbers));
                                    break;
                            }

                        }
                        else if (input == "print")
                        {
                            Console.Write("-> ");
                            int counter = 1;
                            numbers.ForEach(n =>
                            {
                                if (counter == numbers.Count)
                                {
                                    Console.Write(n + "\n");
                                }
                                else
                                {
                                    counter++;
                                    switch (numInput)
                                    {
                                        case 1:
                                            Console.Write(n + " + ");
                                            break;
                                        case 2:
                                            Console.Write(n + " - ");
                                            break;
                                        case 3:
                                            Console.Write(n + " / ");
                                            break;
                                        case 4:
                                            Console.Write(n + " * ");
                                            break;

                                    }

                                }
                            });
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Command not found!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("the list is empty");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
               
            }
            
        }

        private static int Add(List<int> num)
        {
            return num.Sum();
        }
       
        private static int Sub(List<int> num)
        {
            return num[0] - (num.Sum() - num[0]);
        }

        private static double Div(List<int> num)
        {
            return num[0] / num[1];
        }

        private static int Mul(List<int> num)
        {
            return num[0] * num[1];
        }
    }
}
