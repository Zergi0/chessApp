using chessApp.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Game
{
    public interface IGame
    {
        List<BasePiece> Pieces { get;}
        void CreateBaseBoard();
        void MovePieceTo(BasePiece from, Location to);

    }
}

