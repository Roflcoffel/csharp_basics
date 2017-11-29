using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare {
    class Square {
        public int[,] Grid { set; get; }

        Square()
        {
            Grid = new int[3, 3];
        }

        //Sums all 3 col
        public int[] SumCol()
        {
            return new int[3];
        }

        public int[] SumRow(int row)
        {
            return new int[3];
        }

        public int[] SumDia()
        {
            return new int[2];
        }
    }
}
