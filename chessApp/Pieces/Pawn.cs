using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    class Pawn : BasePiece
    {
        public Pawn(string Color, Location location) : base(Color, location)
        {
        }

        public override List<Location> CanMoveTo()
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(Location LocationToMove)
        {
            throw new NotImplementedException();
        }
    }
}
