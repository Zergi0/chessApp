using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    public class Location
    {
        public Location(string x, int y)
        {
            X = x;
            Y = y;
        }

        public string X { get; set; }
        public int Y { get; set; }
    }
}
