using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.View {
    class Draw {

        public int Height { get; } = 20;
        public int Width { get; } = 50;
        public string[,] Map { get; private set; }

        public Draw()
        {
            Map = new string[Height, Width];

            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Map[y, x] = ".";
                }
            }
        }

        public void Update()
        {
            string scene = "";
            //Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    scene += Map[y, x];
                }
                scene += "\n";
            }
            Console.Clear();
            Console.Write(scene);
        } 
    }
}
