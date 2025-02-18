using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    public class Location
    {
        public Location(char x, int y)
        {
            X = x; //letter
            Y = y; //number
        }
        public override string ToString()
        {
            return X+ "" + Y;
        }

        public int GetXAsNumber()
        {
            if (X >= 'A' && X <= 'H')
            {
                return X - 'A' + 1;
            }
            throw new ArgumentException("Invalid letter! Invalid data at Location: " + X + "" + Y);
        }

        public char X { get; set; }
        public int Y { get; set; }
    }
}
