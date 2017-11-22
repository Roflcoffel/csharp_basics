using System;
using DodgeGame.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeGame.View;

namespace DodgeGame.Controller {
    class Input : World{
        public void ProcessInput(Character p, string[,] map)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            keyInfo = Console.ReadKey(true);

            

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    Queue.Add(new Code(() => p.MoveLeft()));
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
                case ConsoleKey.E:
                    p.Slash(map);
                    break;
                default:
                    break;

            }

        }
    }
}
