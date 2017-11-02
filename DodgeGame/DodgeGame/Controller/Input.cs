using System;
using DodgeGame.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Controller {
    class Input {
        public void ProcessInput(Character p)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    p.MoveLeft();
                    break;
                case ConsoleKey.D:
                    p.MoveRight();
                    break;
                case ConsoleKey.W:
                    p.MoveUp();
                    break;
                case ConsoleKey.S:
                    p.MoveDown();
                    break;
                default:
                    break;

            }

        }
    }
}
