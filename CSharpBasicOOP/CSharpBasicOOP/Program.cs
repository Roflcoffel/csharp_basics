using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicOOP {
    class Program {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Person person = new Person("Andreas", "Johansson", 24);
            person.Speak();

            //1.3 Output is the namespace followed by class name.
            //1.4 Output is the return value from the ToString method.
            Console.WriteLine("\n" + person);

            Person person2 = new Person("Mattias", "Johansson", 22);
            //1.5 instanceCount should be 2 at this point.

            //1.6
            Employee employee = new Employee("Andreas", "Johansson", 24, 25000);
            Client client = new Client();

            ObjectFrom(employee);
            ObjectFrom(client);

            //1.7 and 1.8
            employee.AddSale(new Sale("Keyboard", 50, client));
            employee.AddSale(new Sale("Piano", 2000, client));
            employee.AddSale(new Sale("Synth", 535, client));
            employee.AddSale(new Sale("Computer", 653, client));

            employee.GetSaleStatistics();

            Console.ReadLine();
        }

        public static void ObjectFrom(Person person)
        {
            Console.Write("\n" + person);
        }
    }
}
