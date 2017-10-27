using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    class Bus : EngineVehicle, IDriveable {

        private double maxFuel = 150.0;
        private double maxSpeed = 120.0;

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
            Console.WriteLine("Break (Bus)");
        }

        public void Gas()
        {
            Console.WriteLine("Gas (Bus)");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start Engine (Bus)");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop Engine (Bus)");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Turn Left (Bus)");
        }

        public void TurnRight()
        {
            Console.WriteLine("Turn Right (Bus)");
        }
    }
}
