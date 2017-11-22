using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class World {
        public List<Code> Queue { get; set; }

        public World()
        {
            Queue = new List<Code>();
        }
    }
}
