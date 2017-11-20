using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCalculatorTDD {
    class StringCalculator {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            Regex isOneDigit = new Regex(@"^\d$"); //Match One Digit

            if(isOneDigit.IsMatch(numbers))
            {
                return Convert.ToInt32(numbers);
            }

            string[] arrayNums = numbers.Split(',');

            int result = Convert.ToInt32(arrayNums[0]) + Convert.ToInt32(arrayNums[1]);

            return result;
        }
    }
}
