using chessApp.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessApp.Game
{
    public class Game : IGame
    {
        public IBoard board {  get; set; }

       
    }
}
