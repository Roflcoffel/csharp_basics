using DodgeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame.View {
    class Draw : World {

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
            
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    scene += Map[y, x];
                }
                scene += "\n";
            }
            Console.SetCursorPosition(0, 0);
            //Console.Clear();
            ColorLetterInString(scene, '@', ConsoleColor.Green);
        }

        private void ColorLetterInString(string letters, char c, ConsoleColor Color)
        {
            var index = letters.IndexOf(c);
            Console.Write(letters.Substring(0, index));
            Console.ForegroundColor = Color;
            Console.Write(letters[index]);
            Console.ResetColor();
            Console.WriteLine(letters.Substring(index + 1));
        }
    }
}
