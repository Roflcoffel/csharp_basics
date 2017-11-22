using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCalculatorTDD {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            Regex isOneDigit = new Regex(@"^\d$");

            if (isOneDigit.IsMatch(numbers))
            {
                return Convert.ToInt32(numbers);
            }

            Regex optinalDelimiter = new Regex(@"[\%\.\,\*\;]+\]?\n");
            char selectedDelimiter = ',';
            bool useOptonal = optinalDelimiter.IsMatch(numbers) ? true : false;

            Regex optinalManyDelimiter = new Regex(@"^\[");
            bool useManyDelimiter = optinalManyDelimiter.IsMatch(numbers) ? true : false;

            Regex twoDelimiters = new Regex(@"\]\[");
            bool useTwoDelimiters = twoDelimiters.IsMatch(numbers) ? true : false;
            char secondDelimiter = ',';

            string[] mathOperation = new string[100];

            Regex delimiters;

            if (useOptonal)
            {
                //The input does not contain any []
                selectedDelimiter = numbers.Substring(0, 1).ToCharArray()[0];

                if (useManyDelimiter)
                {
                    //The input does contain TWO []
                    
                    //Select the first delimiter
                    selectedDelimiter = numbers.Substring(1, 1).ToCharArray()[0];

                    //Start of math expression
                    mathOperation = Regex.Split(numbers, @"\]\n");

                    if (useTwoDelimiters)
                    {
                        //Split the input to get the second delimiter
                        string[] delimiterSplit = Regex.Split(numbers, @"\]\[");

                        //Select the second delimiter
                        secondDelimiter = delimiterSplit[1].Substring(0, 1).ToCharArray()[0];

                        //Split the input to get the start of the math expression
                        mathOperation = Regex.Split(delimiterSplit[1], @"\]\n");
                    }

                    //And Set;
                    numbers = mathOperation[1];
                }
                else
                {
                    numbers = numbers.Substring(2);
                }

                if(useTwoDelimiters)
                {
                    delimiters = new Regex($@"[\n\{selectedDelimiter}\{secondDelimiter}]+");
                }
                else
                {
                    delimiters = new Regex($@"[\n\{selectedDelimiter}]+");
                }
            }
            else
            {
                delimiters = new Regex(@"[\n\,]+");
            }

            string[] arrayNums = delimiters.Split(numbers);

            string[] negativeNums = arrayNums.Where(
                x => Convert.ToInt32(x) < 0
            ).ToArray();

            if(negativeNums.Length != 0)
            {
                throw new NegativeNumberException("Negatives not allowed", negativeNums);
            }

            int result = arrayNums
                .Where(x => Convert.ToInt32(x) <= 1000)
                .Sum(x => Convert.ToInt32(x));

            return result;
        }
    }
}
