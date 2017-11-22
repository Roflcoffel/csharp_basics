using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTDD {
    public class FizzBuzz {
        //Currently does not recursively check how
        //many times an input is divisible by ex. 5;
        public string FizzBuzzCalc(int input)
        {
            string s = "";

            if (input % 5 == 0)
            {
                s += "Fizz";
            }

            if (input.ToString().Contains("5"))
            {
                s += "Fizz";
            }

            if(input % 7 == 0)
            {
                s += "Buzz";
            }

            if (input.ToString().Contains("7"))
            {
                s += "Buzz";
            }

            if (s == "")
            {
                return input.ToString();
            }
            else
            {
                return s;
            }
        }
    }
}
