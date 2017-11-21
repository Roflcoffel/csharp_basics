using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTDD {
    public class NegativeNumberException : Exception {
        public NegativeNumberException()
        {

        }

        public NegativeNumberException(string message) 
            : base(message)
        {

        }

        public NegativeNumberException(string message, string[] input)
        {
            Console.WriteLine(message);

            foreach (var negativeNum in input)
            {
                Console.WriteLine(negativeNum);
            }
        }
    }
}
