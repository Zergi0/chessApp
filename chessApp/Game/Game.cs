using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chessApp.Pieces;

namespace chessApp.Game
{
    public class Game : IGame
    {
        public List<BasePiece> Pieces { get; set; }

        public Game() 
        {
            Pieces = [];
        }

        public void MovePieceTo(BasePiece from, Location to)
        {
            
        }

        private bool IsThereAPieceAt(Location location)
        {
            return Pieces.Any(a => a.Location.X == location.X && a.Location.Y == location.Y);

        }

        //creates a basic standard chess board
        public void CreateBaseBoard()
        {
            Pieces = new List<BasePiece>
            {
                new Pawn(Colour.black, new Location('A', 7)),
                new Pawn(Colour.black, new Location('B', 7)),
                new Pawn(Colour.black, new Location('C', 7)),
                new Pawn(Colour.black, new Location('D', 7)),
                new Pawn(Colour.black, new Location('E', 7)),
                new Pawn(Colour.black, new Location('F', 7)),
                new Pawn(Colour.black, new Location('G', 7)),
                new Pawn(Colour.black, new Location('H', 7)),
                new Pawn(Colour.white, new Location('A', 2)),
                new Pawn(Colour.white, new Location('B', 2)),
                new Pawn(Colour.white, new Location('C', 2)),
                new Pawn(Colour.white, new Location('D', 2)),
                new Pawn(Colour.white, new Location('E', 2)),
                new Pawn(Colour.white, new Location('F', 2)),
                new Pawn(Colour.white, new Location('G', 2)),
                new Pawn(Colour.white, new Location('H', 2)),
            };
        }
    }
}
