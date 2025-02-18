using chessApp.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Board
{
    public class Board : IBoard
    {
        public List<BasePiece> Pieces { get; set; }


        public Board(List<BasePiece> pieces)
        {
            Pieces = pieces;
        }
    }
}
