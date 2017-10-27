using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    class Program {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bus bus = new Bus();
            Motorbike motorbike = new Motorbike();

            Drive(bus);

            Console.ReadLine();
        }

        //2 an interface could be beneficial when:
        //you want to obfuscate the implementation.
        //you want another programmer writing their own implementations.
        public static void Drive(IDriveable driveable)
        {
            driveable.StartEngine();
            driveable.Gas();
            driveable.TurnLeft();
            driveable.TurnRight();
            driveable.TurnRight();
            driveable.Break();
            driveable.StopEngine();
        }
    }
}
