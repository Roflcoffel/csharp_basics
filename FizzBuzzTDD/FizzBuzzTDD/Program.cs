using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTDD {
    public class Program {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            FizzBuzz FB = new FizzBuzz();

            //run hundred times.
            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine( FB.FizzBuzzCalc(i) );
            //}
            //Console.ReadLine();

            Console.WriteLine("Input a number for the fizz buzz game");
            do
            {
                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(FB.FizzBuzzCalc(input));
            } while (true);

            
        }
    }
}
