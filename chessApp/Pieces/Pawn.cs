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

        public override List<Location> CanMoveTo(Location LocationOfAllPieces)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(Location LocationToMove)
        {
            throw new NotImplementedException();
        }
    }
}
