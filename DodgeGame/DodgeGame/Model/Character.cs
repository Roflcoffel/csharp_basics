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
        public enum Direction {UP, DOWN, LEFT, RIGHT}

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
            if(ValidMove(Direction.LEFT))
            {
                X -= Speed;
            }
        }

        public void MoveRight()
        {
            SaveMove();
            if (ValidMove(Direction.RIGHT))
            {
                X += Speed;
            } 
        }

        public void MoveUp()
        {
            SaveMove();
            if (ValidMove(Direction.UP))
            {
                Y -= Speed;
            }
        }

        public void MoveDown()
        {
            SaveMove();
            if (ValidMove(Direction.DOWN))
            {
                Y += Speed;
            }
        }

        private void SaveMove()
        {
            Oldx = X;
            Oldy = Y;
        }

        public void Slash(string[,] map)
        {
            //Check around the player
            if(ValidMove(Direction.UP))
            {
                if (map[Y - 1, X] == "E")
                {
                    map[Y - 1, X] = ".";
                }
            }
           
            if(ValidMove(Direction.DOWN))
            {
                if (map[Y + 1, X] == "E")
                {
                    map[Y + 1, X] = ".";
                }
            }
           
            if(ValidMove(Direction.LEFT))
            {
                if (map[Y, X - 1] == "E")
                {
                    map[Y, X - 1] = ".";
                }
            }
            
            if (ValidMove(Direction.RIGHT))
            {
                if (map[Y, X + 1] == "E")
                {
                    map[Y, X + 1] = ".";
                }
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

        private bool ValidMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return Y >= 1 ? true : false;
                case Direction.DOWN:
                    return Y <= window.Height - 2 ? true : false;
                case Direction.LEFT:
                    return X >= 1 ? true : false;
                case Direction.RIGHT:
                    return X <= window.Width - 2 ? true : false;
                default:
                    return false;
            }
        }

        private bool ValidMove(Direction direction, int offset)
        {
            switch (direction)
            {
                case Direction.UP:
                    return Y-offset >= 1 ? true : false;
                case Direction.DOWN:
                    return Y+offset <= window.Height - 2 ? true : false;
                case Direction.LEFT:
                    return X-offset >= 1 ? true : false;
                case Direction.RIGHT:
                    return X+offset <= window.Width - 2 ? true : false;
                default:
                    return false;
            }
        }
    }
}
