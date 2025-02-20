using chessApp.Game;
using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public class ChessService : IChessService
    {

        private IGame game;

        public ChessService(IGame game)
        {
            this.game = game;
        }

        public void CreateNewBoard()
        {
            game.CreateBaseBoard();
        }

        public List<BasePiece> GetPieces()
        {
            Console.WriteLine(game.Pieces.Count);
            return game.Pieces;
        }
    }
}
