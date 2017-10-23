using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.Model {
    class Player : Entity 
    {
        public string Marker { get; } = "@";

        public void MoveLeft()
        {
            SaveMove();
            X -= Speed;
        }

        public void MoveRight()
        {
            SaveMove();
            X += Speed;
        }

        public void MoveUp()
        {
            SaveMove();
            Y -= Speed;
        }

        public void MoveDown()
        {
            SaveMove();
            Y += Speed;
        }

        private void SaveMove()
        {
            Oldx = X;
            Oldy = Y;
        }
    }
}
