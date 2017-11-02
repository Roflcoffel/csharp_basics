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

            Random rnd = new Random();

            Input input = new Input();
            Draw draw = new Draw();
            Character player = new Character("@", 3, 1);

            player.X = draw.Width / 2;
            player.Y = draw.Height - 2;


            List<Character> Enemies = Character.generateEnemies(
                20, 
                rnd, 
                new string[] { "E" }
            );

            Enemies.ForEach(
                enemy => {
                    enemy.X = rnd.Next(0, draw.Width);
                    enemy.Y = rnd.Next(0, draw.Height/3);
                }
            );

            Enemies.ForEach(enemy => draw.Map[enemy.Y, enemy.X] = enemy.Marker);

            //Kör draw bara om det finns något att uppdatera.
            //Så varje gång något rör sig lägg det i en array
            //och loppa igenom array och ta bort för varje
            //när den är tom sluta uppdatera.
            //kräver en for loop inom while loop med en check på
            //om arrayen är tom.
            while (true)
            {
                draw.Map[player.Y, player.X] = player.Marker;

                draw.Update();

                
                input.ProcessInput(player);

                draw.Map[player.Oldy, player.Oldx] = ".";


                //Debug.WriteLine("OLD Y: " + player.Oldy + " OLD X: " + player.Oldx);
                Debug.WriteLine("Current Y: " + player.Y + " Current X: " + player.X);

            }
        }

        
    }
}
