using DodgeGame.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class Character : Entity 
    {
        public string Marker { get; set; }
        private Draw window = new Draw();

        public Character(string Marker, int Health, int Speed)
        {
            this.Marker = Marker;
            this.Health = Health;
            this.Speed = Speed;

            X = 0;
            Y = 0;
            Oldx = X;
            Oldy = Y;
        }

        public void MoveLeft()
        {
            SaveMove();
            if(X >= 1)
            {
                X -= Speed;
            }
        }

        public void MoveRight()
        {
            SaveMove();
            if (X <= window.Width-2)
            {
                X += Speed;
            } 
        }

        public void MoveUp()
        {
            SaveMove();
            if (Y >= 1)
            {
                Y -= Speed;
            }
        }

        public void MoveDown()
        {
            SaveMove();
            if (Y <= window.Height-2)
            {
                Y += Speed;
            }
        }

        private void SaveMove()
        {
            Oldx = X;
            Oldy = Y;
        }

        public void Slash()
        {
            //Check around the player

            if (window.Map[X,Y-1] == "E")
            {
                window.Map[X, Y - 1] = ".";
            }

            if(window.Map[X,Y+1] == "E")
            {
                window.Map[X, Y + 1] = ".";
            } 

            if(window.Map[X-1,Y] == "E")
            {
                window.Map[X-1, Y] = ".";
            }

            if(window.Map[X+1,Y] == "E")
            {
                window.Map[X+1, Y] = ".";
            }
        }

        public static List<Character> generateEnemies(int count, Random rnd, string[] markers)
        {
            List<Character> temp = new List<Character>();

            for (int i = 0; i < count; i++)
            {
                temp.Add(new Character(markers[rnd.Next(0, markers.Length-1)], rnd.Next(1, 3), 1));
            }

            return temp;
        }
    }
}
