using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class Code {
        private Action Runner { get; set; }

        public Code(Action function)
        {
            Runner = function;
        }

        public void Run()
        {
            Runner();
        }
    }
}
