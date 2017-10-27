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
                return base.Fuel;
            }
            set
            {
                if (base.Fuel <= maxFuel)
                {
                    base.Fuel = value;
                }
                else
                {
                    base.Fuel = maxFuel;
                    Console.WriteLine("MAX FUEL");
                }
            }
        }

        public override double Speed
        {
            get
            {
                return base.Speed;
            }
            set
            {
                if (base.Speed < maxSpeed)
                {
                    base.Speed = value;
                }
                else
                {
                    base.Speed = maxSpeed;
                    Console.WriteLine("MAX Speed");
                }
            }
        }

        public void Break()
        {
            Console.WriteLine("Break (Bus)\n");
            Speed -= 10;
            Console.WriteLine("Current Speed: " + Speed);
        }

        public void Gas()
        {
            Console.WriteLine("Gas (Bus)\n");
            Speed += 10;
            Fuel -= 1;
            Console.WriteLine("Current Speed: " + Speed);
            Console.WriteLine("Current Fuel: " + Fuel);
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
