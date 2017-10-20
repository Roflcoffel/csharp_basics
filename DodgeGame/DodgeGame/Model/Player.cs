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
            this.X -= this.Speed;
        }

        public void MoveRight()
        {
            this.X += this.Speed;
        }
    }
}
