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

            //A
            Regex optinalDelimiter = new Regex(@"[\%\.\,\*\;]+\]?\n");
            char selectedDelimiter = ',';
            bool useOptonal = optinalDelimiter.IsMatch(numbers) ? true : false;

            //B; If B is true then A has to also be true
            Regex optinalManyDelimiter = new Regex(@"^\[");
            bool useManyDelimiter = optinalManyDelimiter.IsMatch(numbers) ? true : false;

            //C; if C is true then B has to also be true
            Regex twoDelimiters = new Regex(@"\]\[");
            bool useTwoDelimiters = twoDelimiters.IsMatch(numbers) ? true : false;

            Regex delimiters;

            if (useOptonal)
            {
                selectedDelimiter = numbers.Substring(0, 1).ToCharArray()[0];

                if (useManyDelimiter)
                {
                    selectedDelimiter = numbers.Substring(1, 1).ToCharArray()[0];

                    string[] delimiterCount = Regex.Split(numbers, @"\]\n");

                    numbers = numbers.Substring(delimiterCount[0].Length + 2);
                }
                else if(useTwoDelimiters)
                {
                    //firstDelimiter = numbers.Substring(1, 1).ToCharArray()[0];
                    //secondDelimiter = numbers.Substring();
                }
                else
                {
                    numbers = numbers.Substring(2);
                }

                delimiters = new Regex($@"[\n\{selectedDelimiter}]+");
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
