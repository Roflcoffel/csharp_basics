using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PracticalCalculator {
    class Program {
        static void Main(string[] args)
        {
            string[] operators = new string[4] { "*", "/", "+", "-" };

            bool run = true;
           

            MainMenu();
            
            string input = Console.ReadLine();

            while (run)
            {
                Console.WriteLine(input);
                input = processInput(input, operators);
                bool isNumeric = Regex.IsMatch(input, @"^\d+$");
                if (isNumeric)
                {
                    Console.WriteLine(Convert.ToInt32(input));

                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                    input = Console.ReadLine();

                }

                if(input == "Error") {
                    Console.WriteLine("Wrong Format!");

                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                    input = Console.ReadLine();
                }

                if(input == "q")
                {
                    run = false;
                }
            }

            //Console.ReadKey();
        }

        private static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Practical Calculator--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-> ");
        }

        private static string processInput(string input, string[] ops)
        {
            bool isNumeric = false;
            int stringStart = 0;
            int stringEnd = 0;

            input = input.Replace(" ", string.Empty);

            for (int i = 0; i < ops.Length; i++)
            {
                if(input.Contains(ops[i]))
                {
                    int pos = input.IndexOf(ops[i]);

                    for (int j = 0; j < input.Length; j++)
                    {
                        if (pos - j - 1 >= 0)
                        {
                            isNumeric = Regex.IsMatch(input.Substring(pos - j - 1, 1), @"^\d+$");
                            if (!isNumeric)
                            {
                                stringStart = pos - j;
                            }
                        }
                        else
                        {
                            stringStart = 0;
                        }

                        if (input.Length > pos + j + 1)
                        {
                            isNumeric = Regex.IsMatch(input.Substring(pos + j + 1, 1), @"^\d+$");
                            if (!isNumeric)
                            {
                                stringEnd = pos + j + 1;
                            }

                        }
                        else
                        {
                            stringEnd = input.Length;
                        }

                        string subInput = input.Substring(stringStart, stringEnd - stringStart);

                        if (Regex.IsMatch(subInput, @"^\d+[\+\*\-\/]\d+$"))
                        {
                            string answer = Evaluate(subInput, ops);
                            string result = input.Replace(subInput, answer);
                            return result;

                        }

                        Console.ReadKey();
                    }
                }

            
            }
            return "Error";
            
        }

        private static string Evaluate(string formula, string[] ops)
        {
            //Operands; values next to operator
            string[] operands = new string[2]; 
            string currentOperator = "";

            for (int i = 0; i < ops.Length; i++)
            {
                if (formula.Contains(ops[i]))
                {
                    operands = formula.Split(Convert.ToChar(ops[i]));
                    currentOperator = ops[i];
                }
            }

            int a = Convert.ToInt32(operands[0]);
            int b = Convert.ToInt32(operands[1]);

            switch (currentOperator)
            {
                case "*":
                    return Mul(a, b).ToString();
                case "/":
                    return Div(a, b).ToString();
                case "+":
                    return Add(a, b).ToString();
                case "-":
                    return Sub(a, b).ToString();
                default:
                    return "1";
            }
        }

        private static int Add(int val1, int val2)
        {
            return val1 + val2;
        }

        private static int Sub(int val1, int val2)
        {
            return val1 - val2;
        }

        private static double Div(int val1, int val2)
        {
            return val1 / val2;
        }

        private static int Mul(int val1, int val2)
        {
            return val1 * val2;
        }
    }
}
