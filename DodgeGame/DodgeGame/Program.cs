using DodgeGame.View;
using DodgeGame.Model;
using DodgeGame.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DodgeGame {
    class Program {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Input input = new Input();
            Draw draw = new Draw();
            Player player = new Player()
            {
                Health = 3,
                Speed = 1,
                X = draw.Width / 2,
                Y = draw.Height / 2,
                
            };

            player.Oldx = player.X;
            player.Oldy = player.Y;

            while(true)
            {
                draw.Map[player.Y, player.X] = player.Marker;

                draw.Update();

                input.ProcessInput(ref player);

                draw.Map[player.Oldy, player.Oldx] = ".";

                //Debug.WriteLine("OLD Y: " + player.Oldy + " OLD X: " + player.Oldx);
                Debug.WriteLine("Current Y: " + player.Y + " Current X: " + player.X);

            }
        }
    }
}
