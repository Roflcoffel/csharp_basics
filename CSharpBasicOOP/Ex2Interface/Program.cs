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
            car.Fuel = 70;
            Drive(car);

            Console.ReadLine();
        }

        //2 an interface could be beneficial when:
        //you have something that can be applied to many objects, ex. driveable
        //to ensure that any object created by another programmer will work with your code.
        //you want to obfuscate the implementation / create more abstraction.
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
