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
            Console.WriteLine("Break (Car)\n");
            Speed -= 10;
            Console.WriteLine("Current Speed: " + Speed);
        }

        public void Gas()
        {
            Console.WriteLine("Gas (Car)\n");
            Speed += 10;
            Fuel -= 1;
            Console.WriteLine("Current Speed: " + Speed);
            Console.WriteLine("Current Fuel: " + Fuel);

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
