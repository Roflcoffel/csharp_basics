using System;
using DodgeGame.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Controller {
    class Input {
        public void ProcessInput(ref Player p)
        {
            ConsoleKeyInfo Key = new ConsoleKeyInfo();
            Key = Console.ReadKey(true);

            switch (Key.KeyChar)
            {
                case 'a':
                    p.MoveLeft();
                    break;
                case 'd':
                    p.MoveRight();
                    break;
            }
        }
    }
}
