using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Interface {
    abstract class EngineVehicle {
        //3.1
        //These create a hidden backing field;
        public virtual double Fuel { get; set; }
        public virtual double Speed { get; set; }

        public EngineVehicle()
        {
            Fuel = 0.0;
            Speed = 0.0;
        }
    }
}
