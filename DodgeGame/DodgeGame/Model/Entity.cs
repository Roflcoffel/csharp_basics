using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class Entity : World {
        public int Health { get; set; }
        public int Speed { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Oldx { get; set; }
        public int Oldy { get; set; }
    }
}
