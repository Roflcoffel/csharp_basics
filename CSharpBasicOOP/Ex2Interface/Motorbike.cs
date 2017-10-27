using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    class Motorbike : EngineVehicle, IDriveable {

        private double maxFuel = 40.0;
        private double maxSpeed = 160.0;

        public override double Fuel {
            get
            {
                return Fuel;
            }
            set
            {
                if(Fuel < maxFuel)
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
            Console.WriteLine("Break (Motorbike)");
        }

        public void Gas()
        {
            Console.WriteLine("Gas (Motorbike)");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start Engine (Motorbike)");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop Engine (Motorbike)");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Turn Left (Motorbike)");
        }

        public void TurnRight()
        {
            Console.WriteLine("Turn Right (Motorbike)");
        }
    }
}
