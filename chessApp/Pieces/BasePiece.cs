﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Pieces
{
    public abstract class BasePiece
    {
        abstract public List<Location> CanMoveTo(Location LocationOfAllPieces);
        abstract public void MoveTo(Location LocationToMove);

        public void GetTaken()
        {
            Alive = false;
        }

        public Colour Colour { get; set; }
        public Location Location {  get; set; }
        public Boolean Alive { get; private set; }


        public BasePiece(Colour colour, Location location)
        {
            Colour = colour;
            Location = location;
            Alive = true;
        }
    }
}
