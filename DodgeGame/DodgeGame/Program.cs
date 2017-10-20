using DodgeGame.View;
using DodgeGame.Model;
using DodgeGame.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame {
    class Program {
        static void Main(string[] args)
        {
            Input input = new Input();
            Draw draw = new Draw();
            Player player = new Player()
            {
                Health = 3,
                Speed = 1,
                X = draw.Width / 2,
                Y = draw.Height / 2
            };

            while(true)
            {
                

                input.ProcessInput(ref player);
                Console.Clear();

                draw.Map[player.Y, player.X] = player.Marker;

                draw.Run();

                
            }
        }
    }
}
