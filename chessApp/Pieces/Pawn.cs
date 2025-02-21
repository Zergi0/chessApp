using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    class Pawn : BasePiece
    {
        public Pawn(Colour Colour, Location location) : base(Colour, location)
        {
        }

        //TODO
        public override bool CanMoveTo(Location to, List<BasePiece> pieces)
        {
            return true;
        }
    }
}
