using DodgeGame.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class Player : Entity 
    {
        public string Marker { get; } = "@";
        private Draw window = new Draw();

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
            // the total width is 50 (0-49)
            // so the last check has to be on 48
            // hence the -2.
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
    }
}
