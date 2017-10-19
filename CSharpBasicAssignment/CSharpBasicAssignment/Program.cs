using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_CSharpGund
{
    class Program
    {
        private static void RunExerciseOne()
        {
            string firstName = "Andreas";
            string lastName = "Johansson";

            Console.WriteLine("Hello {0} {1} I’m glad to inform you" +
                "that you are the test subject of my very first assignment", 
                firstName, 
                lastName
            );
        }

        private static void RunExerciseTwo()
        {
            Console.WriteLine("What is your firstname? ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is your lastname? ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Hello {0} {1}! Have a nice day!",
                firstName,
                lastName    
            );
        }

        private static void RunExerciseThree()
        {
            Console.WriteLine("When is your birthday? (YYYY-MM-DD) ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            int age = DateTime.Now.Year - date.Year;

            if(DateTime.Now.Day <= date.Day)
            {
                if (DateTime.Now.Month <= date.Month)
                {
                    age--;
                }
            }

            Console.WriteLine("Your age is {0}", age);
        }
        
        private static void RunExerciseFour()
        {
            Console.WriteLine("Year-month-day " + DateTime.Now.ToString("yyyy mm dd"));
            Console.WriteLine("Day-month-year " + DateTime.Now.ToString("dd mm yyyy"));

            Console.WriteLine("\nTomorrows Date: " + DateTime.Now.AddDays(1));
            Console.WriteLine("Yesterdays Date: " + DateTime.Now.AddDays(-1));
        }

        private static void RunExerciseFive()
        {
            // A)
            double intSum = 3 + 5;

            // B)
            int decimalSum = (int) 0.55 + (int) 0.20;

            // C)
            int even = 4;
            int odd = 5;

            double divisonSum = (double) odd / (double) even;

            Console.WriteLine("Division Result: {0}", divisonSum);

        }

        private static void RunExerciseSix()
        {
            // A)
            string sentence = "The quick fox Jumped Over the DOG".ToLower().Substring(1).Insert(0,"T");
            
            // B)
            Console.WriteLine("\nB)\nwrite a word: ");
            string wordOne = Console.ReadLine();

            Console.WriteLine("write a second word: ");
            string wordTwo = Console.ReadLine();

            Console.WriteLine(
                String.Compare(
                    wordOne, wordTwo, false
                ) == 0 ? "The words are equal" : "The words are NOT equal"
            );

            // C)
            Console.WriteLine("\nC)\nInput word is Donkey");
            string input = "Donkey";

            Console.WriteLine("\nResult: M{0}", input.Substring(1));

            // D)
            string textBlock = "I am going to visit Kolmården zoo tomorrow.\n" +
                "I am a big fan of the dolphin show.I may watch all dolphin shows during the day.\n" +
                "I would like to take a gondola safari as well. I wish to visit Bamse and his team there.";

            Console.WriteLine("\nD)\nReplace exercise; 'I' with 'We' and 'am' with 'are'\n\n{0}",
                textBlock
                .Replace("I", "We")
                .Replace("am", "are")
            );


            Console.WriteLine("\n\n Press a key to display the result for part E) to H)!");
            Console.ReadKey();
            

            // E)
            string statment = "She is the popular singer.".Insert(10, " most");

            Console.WriteLine("\nE)\nInsert Exercise: {0}", statment);

            // F)
            string statment2 = "A friend is the asset of your life.".Insert(2, "true ");

            Console.WriteLine("\nF)\nInsert Exercise again?: {0}", statment2);

            // G)
            string name = "My Name is Nalini Phopase";

            Console.WriteLine("\nG\nSubstring Exercise Result: {0}", name.Substring(11));

            // H)
            string statment3 = "Arrays are very common in programming, " +
                "they look something like: [1,2,3,4,5]";

            string[] array = {"4", "5", "6", "7", "8"};
            string sep = ",";

            statment3 = statment3.Substring(statment3.Length-11, 3);
            string result = String.Join(sep, array);

            Console.WriteLine("\nH)\nRidiculous String Manipulaion: {0}", statment3 + result + "]");
        }

        private static void RunExerciseSeven()
        {
            int x = 40;
            int y = 20;
            int z = 25;
            int m = 15;
            int e, f, g;
            e = (x + y) * z / m;
            f = x + y * (z / m);
            g = x + y * z / m;

            Console.WriteLine("E = " + e);
            Console.WriteLine("F = " + f);
            Console.WriteLine("g = " + g);
        }

        private static void RunExerciseEight()
        {
            Console.WriteLine("Enter a positive integer: ");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(input % 2 == 0 ? "Your number is even" : "Your number is odd");
        }

        private static void RunExerciseNine()
        {
            var numbers = new List<int>();

            var even = new List<int>();
            var odd = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i <= 20; i++)
            {
                numbers.Add(rnd.Next(1,100));
            }

            even = numbers.Where(n => n % 2 == 0).ToList();
            odd = numbers.Where(n => n % 2 != 0).ToList();

            Console.WriteLine("Even List: ");
            even.ForEach(n => Console.WriteLine(n));

            Console.WriteLine("\nOdd List: ");
            odd.ForEach(n => Console.WriteLine(n));
           
            
        }

        private static void RunExerciseTen()
        {
            // Sphere A = 4pir^2;
            // Circle A = pir^2

            Console.WriteLine("Input a value for radius: ");

            int radius = Convert.ToInt32(Console.ReadLine());
            double pi = Math.PI;

            double circleArea = pi * Math.Pow(radius, 2);
            double sphereArea = 4 * pi * Math.Pow(radius, 2);

            Console.WriteLine("The Circle Area is: {0}", circleArea);
            Console.WriteLine("The Sphere Area is: {0}", sphereArea);

        }

        private static void RunExerciseEleven()
        {
            int[] numbers = new int[10];

            Console.WriteLine("Please enter 10 numbers: ");

            for (int i = 0; i <= 9; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Negative Number list: ");

            numbers.Where(n => n < 0)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
          
        }

        private static void RunExerciseTwelve()
        {
            Console.WriteLine("What is your body temperature in Celsius? ");
            double temp = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(temp > 37 ? "You have a fever" : "you do not have a fever");
        }

        private static void RunExerciseThirteen()
        {
            Console.WriteLine("What's your name? ");
            string name = Console.ReadLine();

            int age = CalculateAge();

            if (age >= 18)
            {
                Console.WriteLine("Do you want to order a beer? ");
                string answer1 = Console.ReadLine();

                if( answer1.ToLower() == "yes")
                {
                    Console.WriteLine("your beer has been served");
                }
                else if( answer1.ToLower() == "no")
                {
                    Console.WriteLine("Do you want to order a coke? ");
                    string answer2 = Console.ReadLine();

                    if (answer2.ToLower() == "yes")
                    {
                        Console.WriteLine("your coke has been served");
                    }
                    else if (answer2.ToLower() == "no")
                    {
                        Console.WriteLine("no more order options");
                    }
                }
            }
            else
            {
                Console.WriteLine("Do you want to order a coke? ");
                string answer2 = Console.ReadLine();

                if (answer2.ToLower() == "yes")
                {
                    Console.WriteLine("your coke has been served");
                }
                else if (answer2.ToLower() == "no")
                {
                    Console.WriteLine("no more order options");
                }
            }
        }

        //NOTE: This method is needed for exercise 13!!
        private static int CalculateAge()
        {
            Console.WriteLine("When is your birthday? (YYYY-MM-DD) ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            int age = DateTime.Now.Year - date.Year;

            Console.WriteLine("Your age is {0}", age);

            return age;
        }

        private static void RunExerciseFourteen()
        {
            Console.WriteLine("write an arithmentic operator: ");
            string ops = Console.ReadLine();

            Console.WriteLine("and two operands: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            switch (ops)
            {
                case "+":
                    Console.WriteLine("A + B = {0}", a + b);
                    break;
                case "-":
                    Console.WriteLine("A - B = {0}", a - b);
                    break;
                case "*":
                    Console.WriteLine("A * B = {0}", a * b);
                    break;
                case "/":
                    Console.WriteLine("A / B = {0}", a / b);
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }
        }

        private static void RunExerciseFifteen()
        {
            Console.WriteLine("what grade did you get on the exam? ");
            string grade = Console.ReadLine();

            switch (grade.ToUpper())
            {
                case "A":
                    Console.WriteLine("nicely done!");
                    break;
                case "B":
                    Console.WriteLine("well done!");
                    break;
                case "C":
                    Console.WriteLine("ok!");
                    break;
                case "D":
                    Console.WriteLine("try harder next time");
                    break;
                case "E":
                    Console.WriteLine("maybe stop sleeping in class");
                    break;
                default:
                    break;
            }
        }

        private static void RunExerciseSixteen()
        {
            Console.WriteLine("enter a number smaller than 100: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nAcending For Loop: ");

            // For Loop
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Decending For Loop: ");

            for (int j = 100; j >= num; j--)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("\nAcending While Loop: ");

            // While Loop
            int h = 1;

            while (h <= num)
            {
                //Console.WriteLine(h);
                h++;
            }

            int g = 100;

            Console.WriteLine("Decending While Loop: ");

            while (g >= num)
            {
                //Console.WriteLine(g);
                g--;
            }

            Console.WriteLine("\nAcending Do-While Loop: ");

            // Do-While Loop
            int x = 0;

            do
            {
                //Console.WriteLine(x);
                x++;
            } while (x <= num);


            Console.WriteLine("Decending Do-While Loop: ");

            int z = 100;

            do
            {
                //Console.WriteLine(z);
                z--;
            } while (z >= num);

        }

        private static void RunExerciseSeventeen()
        {
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Console.Write(x * y + " ");
                }

                Console.WriteLine();
            }
        }

        private static void RunExerciseEighteen()
        {
            int input = 1990;

            while (input <= DateTime.Now.Year)
            {
                if(DateTime.IsLeapYear(input))
                {
                    Console.WriteLine(input + " is a leap year");
                }
                
                
                input++;
            }
        }

        private static void RunExerciseNineteen()
        {
            Random SecretNumber = new Random();
            string answer;

            do
            {
                Console.WriteLine("Guess the secret number! (1-10) ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == SecretNumber.Next(1, 10))
                {
                    Console.WriteLine("CORRECT!");
                    break;
                }

                Console.WriteLine("WRONG!");

                Console.WriteLine("do you want to guess again? ");
                answer = Console.ReadLine();

            } while (answer.ToLower() == "yes");
        }

        private static void RunExerciseTwenty()
        {
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine(" ");
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(" ");
                }

                for (int q = i; q <= 4; q++)
                {
                    Console.Write(" * ");
                }
            }

            Console.ReadKey();
        }

        private static void RunExerciseTwentyOne()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter a number: ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == -1)
                {
                    Console.WriteLine("Sum: " + numbers.Sum());
                    Console.WriteLine("Average: " + numbers.Average());

                    break;
                }

                numbers.Add(input);
            } 
        }

        private static void RunExerciseTwentyTwo()
        {
            // Fib n = Fib n - 1 + Fib n -2

            int a = 0, b = 1, c = 0;
            Console.Write($" {a} {b}");

            for (int i = 2; i <= 10; i++)
            {
                c = a + b;
                Console.Write($" {c}");
                a = b;
                b = c;
            }
        }

        private static void RunExerciseTwentyThree()
        {
            Console.Write("enter height: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("enter width: ");
            int width = Convert.ToInt32(Console.ReadLine());

            int triangleArea = (width * height) / 2;

            Console.WriteLine("Triangle Area = " + triangleArea);
        }

        private static void RunExerciseTwentyFour()
        {
            AddNumbers(1, 2);
            AddNumbers(1, 5, 4);
            AddNumbers(1, 2, 5, 1);
        }

        //NOTE: Used in Exercise 24
        private static void AddNumbers(float num1, float num2)
        {
            Console.WriteLine(num1 + num2);
        }

        //NOTE: Used in Exercise 24
        private static void AddNumbers(float num1, float num2, float num3)
        {
            Console.WriteLine(num1 + num2 + num3);
        }

        //NOTE: Used in Exercise 24
        private static void AddNumbers(float num1, float num2, float num3, float num4)
        {
            Console.WriteLine(num1 + num2 + num3 + num4);
        }

        private static void RunExerciseTwentyFive()
        {
            int[] numbers = new int[5] { 2, 4, 10, 4, 5 };
            Console.WriteLine("Largest Number in Array: " + ArrayLargest(numbers) );
        }

        //NOTE: Used int Exercise 25
        private static int ArrayLargest(int[] array)
        {
            int currentLargest = array[0];

            foreach (int number in array)
            {
                if( currentLargest < number)
                {
                    currentLargest = number;
                }
            }

            return currentLargest;
        }

        private static void RunExerciseTwentySix()
        {
            int num1 = 15;
            int num2 = 25;

            Console.WriteLine($"Before Swap: {num1} {num2}");

            Swap26(num1, num2);

            Console.WriteLine($"After Swap: {num1} {num2}");
        }

        //NOTE: Used in Exercise 26
        private static void Swap26(int num1, int num2)
        {
            int temp;

            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine($"Inside Swap Function: {num1} {num2}");
        }

        private static void RunExerciseTwentySeven()
        {
            int num1 = 20;
            int num2 = 50;

            Console.WriteLine($"Before Swap: {num1} {num2}");

            Swap27(ref num1, ref num2);

            Console.WriteLine($"After Swap: {num1} {num2}");
        }

        //NOTE: Used in Exercise 27
        private static void Swap27(ref int num1, ref int num2)
        {
            int temp;

            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine($"Inside Swap Function: {num1} {num2}");
        }

        private static void RunExerciseTwentyEight()
        {
            Console.WriteLine("Input any string, i will check if it's a palindrome: ");
            string input = Console.ReadLine().ToLower();
            char[] reverse = input.ToCharArray();

            Array.Reverse(reverse);
            string result = new string(reverse);

            if (result == input)
            {
                Console.WriteLine("The Word is a palindrome!");
            }
            else
            {
                Console.WriteLine("The Word is not a palindrome!");
            }
        }

        private static void RunExerciseTwentyNine()
        {
            int[] input = new int[12];

            int[] even = new int[12];
            int[] odd = new int[12];

            int eCount = 0;
            int oCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("Enter twelve positive integers: ");
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nInput Array: ");

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);

                if (i % 2 == 0) {
                    even[eCount] = input[i];
                    eCount++;
                }
                else
                {
                    odd[oCount] = input[i];
                    oCount++;
                }
            }

            Console.WriteLine("\nEven Number: ");

            for (int i = 0; i < even.Length; i++)
            {
                Console.WriteLine(even[i]);
            }

            Console.WriteLine("\nOdd Number: ");

            for (int i = 0; i < odd.Length; i++)
            {
                Console.WriteLine(odd[i]);
            }

        }

        private static void RunExerciseThirty()
        {
            int[] numArray = new int[15];
            int[] random = new int[15];

            int end = 14;
            int start = 0;

            Random rnd = new Random();

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = rnd.Next(1, 100);
            }



            for (int i = 0; i < random.Length; i++)
            {
                if(random[i] % 2 == 0 )
                {
                    numArray[start] = random[i];
                    start++;
                }
                else
                {
                    numArray[end] = random[i];
                    end--;
                }
            }

            Console.WriteLine("Array with even to odd order: ");
            numArray.ToList().ForEach(n => Console.WriteLine(n));

        }

        //Sorts numbers largest to smallest
        private static void RunExerciseThirtyOne()
        {
            Random rnd = new Random();

            int[] numArray = new int[rnd.Next(5, 15)];
            int temp = 0;

            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = rnd.Next(1, 100);
            }
            
            for (int i = 0; i < numArray.Length; i++)
            {
                for (int j = 0; j < numArray.Length; j++)
                {
                    if(numArray[i] > numArray[j])
                    {
                        temp = numArray[i];
                        numArray[i] = numArray[j];
                        numArray[j] = temp;
                    }
                }
            }

            numArray.ToList().ForEach(n => Console.WriteLine(n));
        }

        private static void RunExerciseThirtyTwo()
        {
            Random rnd = new Random();

            int[] numArray = new int[rnd.Next(1, 15)];
           
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = rnd.Next(1, 99);
            }

            double[] result = new double[numArray.Length];

            Console.WriteLine("Fill the array with square or cube results? ");
            string input = Console.ReadLine();

            if(input == "square")
            {
                for (int i = 0; i < numArray.Length; i++)
                {
                    result[i] = (double) Math.Pow(numArray[i], 2);
                }
            }
            else if(input == "cube")
            {
                for (int i = 0; i < numArray.Length; i++)
                {
                    result[i] = (double) Math.Pow(numArray[i], 3);
                }
            }

            result.ToList().ForEach(n => Console.WriteLine(n));
        }

        private static void RunExerciseThirtyThree()
        {
            Console.Write("Enter numbers with comma seperator: ");
            string input = Console.ReadLine();

            string[] splitArray = input.Split(',');
            int[] result = new int[splitArray.Length];

            for (int i = 0; i < splitArray.Length; i++)
            {
                result[i] = Convert.ToInt32(splitArray[i]);
            }

            Console.WriteLine("Max: " + result.Max());
            Console.WriteLine("Min: " + result.Min());
            Console.WriteLine("Average: " + result.Average());
        }

        static void Main(string[] args)
        {

            bool keepAlive = true;
            while (keepAlive)
            {
                try
                {
                    Console.Write("Enter assignment number (or -1 to exit): ");
                    var assignmentChoice = int.Parse(Console.ReadLine() ?? "");
                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (assignmentChoice)
                    {
                        case 1:
                            RunExerciseOne();
                            break;
                        case 2:
                            RunExerciseTwo();
                            break;
                        case 3:
                            RunExerciseThree();
                            break;
                        case 4:
                            RunExerciseFour();
                            break;
                        case 5:
                            RunExerciseFive();
                            break;
                        case 6:
                            RunExerciseSix();
                            break;
                        case 7:
                            RunExerciseSeven();
                            break;
                        case 8:
                            RunExerciseEight();
                            break;
                        case 9:
                            RunExerciseNine();
                            break;
                        case 10:
                            RunExerciseTen();
                            break;
                        case 11:
                            RunExerciseEleven();
                            break;
                        case 12:
                            RunExerciseTwelve();
                            break;
                        case 13:
                            RunExerciseThirteen();
                            break;
                        case 14:
                            RunExerciseFourteen();
                            break;
                        case 15:
                            RunExerciseFifteen();
                            break;
                        case 16:
                            RunExerciseSixteen();
                            break;
                        case 17:
                            RunExerciseSeventeen();
                            break;
                        case 18:
                            RunExerciseEighteen();
                            break;
                        case 19:
                            RunExerciseNineteen();
                            break;
                        case 20:
                            RunExerciseTwenty();
                            break;
                        case 21:
                            RunExerciseTwentyOne();
                            break;
                        case 22:
                            RunExerciseTwentyTwo();
                            break;
                        case 23:
                            RunExerciseTwentyThree();
                            break;
                        case 24:
                            RunExerciseTwentyFour();
                            break;
                        case 25:
                            RunExerciseTwentyFive();
                            break;
                        case 26:
                            RunExerciseTwentySix();
                            break;
                        case 27:
                            RunExerciseTwentySeven();
                            break;
                        case 28:
                            RunExerciseTwentyEight();
                            break;
                        case 29:
                            RunExerciseTwentyNine();
                            break;
                        case 30:
                            RunExerciseThirty();
                            break;
                        case 31:
                            RunExerciseThirtyOne();
                            break;
                        case 32:
                            RunExerciseThirtyTwo();
                            break;
                        case 33:
                            RunExerciseThirtyThree();
                            break;

                        case -1:
                            keepAlive = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That is not a valid assignment number!");
                            break;
                    }
                    Console.ResetColor();
                    Console.WriteLine("Hit any key to continue..");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }

        }

    }
}
