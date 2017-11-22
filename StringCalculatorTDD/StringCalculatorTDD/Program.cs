using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTDD {
    class Program {
        static void Main(string[] args)
        {
            StringCalculator StringCalc = new StringCalculator();

            try
            {
                Console.WriteLine(StringCalc.Add("1,-1,1"));
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();
        }
    }
}
