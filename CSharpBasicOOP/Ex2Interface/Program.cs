using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    class Program {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Car car = new Car();
            Bus bus = new Bus();
            Motorbike motorbike = new Motorbike();

            
            //bus.Fuel = 150;

            //Drive(bus);

            //3
            car.Fuel = 50;
            Drive(car);

            Console.ReadLine();
        }

        //2 an interface could be beneficial when:
        //you want to obfuscate the implementation.
        //you want another programmer writing their own implementations.
        public static void Drive(IDriveable driveable)
        {
            driveable.StartEngine();
            driveable.Gas();
            driveable.Gas();
            driveable.TurnLeft();
            driveable.TurnRight();
            driveable.TurnRight();
            driveable.Break();
            driveable.StopEngine();
        }
    }
}
