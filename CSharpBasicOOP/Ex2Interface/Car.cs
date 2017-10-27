using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    class Car : EngineVehicle, IDriveable {

        private double maxFuel = 60.0;
        private double maxSpeed = 160.0;

        public override double Fuel
        {
            get
            {
                return Fuel;
            }
            set
            {
                if (Fuel < maxFuel)
                {
                    Fuel = value;
                }
                else
                {
                    Console.WriteLine("MAX FUEL");
                }
            }
        }

        public override double Speed
        {
            get
            {
                return Speed;
            }
            set
            {
                if (Speed < maxSpeed)
                {
                    Speed = value;
                }
                else
                {
                    Console.WriteLine("MAX Speed");
                }
            }
        }

        public void Break()
        {
            Console.WriteLine("Break (Car)");
        }

        public void Gas()
        {
            Console.WriteLine("Gas (Car)");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start Engine (Car)");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop Engine (Car)");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Turn Left (Car)");
        }

        public void TurnRight()
        {
            Console.WriteLine("Turn Right (Car)");
        }
    }
}
