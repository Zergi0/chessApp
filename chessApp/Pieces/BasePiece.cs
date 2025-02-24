using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    public abstract class BasePiece
    {
        abstract public bool CanMoveTo(Location to, List<BasePiece> pieces);
        public virtual void MoveTo(Location to,List<BasePiece> pieces)
        {
           Location = to;
        }
        public Colour Colour { get; set; }
        public Location Location {  get; set; }


        public BasePiece(Colour colour, Location location)
        {
            Colour = colour;
            Location = location;
        }
    }
}
