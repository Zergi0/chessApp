using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    abstract class BasePiece
    {
        abstract public List<Location> CanMoveTo();
        abstract public void MoveTo(Location LocationToMove);

        public void GetTaken()
        {
            Alive = false;
        }

        private String Color;
        private Location Location;
        private Boolean Alive;


        public BasePiece(String Color, Location location){
            this.Color = Color;
            this.Location = location;
            this.Alive = true;
        }



    }
}
