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
            return game.Pieces;
        }
        
        public BasePiece MovePiece(Location from, Location to)
        {
            try
            {
                return game.MovePieceTo(from, to);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateCustomBoard(List<PieceImport> pieceImports)
        {
            try
            {
                game.CreateCustomBoard(pieceImports);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EmptyTheBoard()
        {
            game.EmptyTheBoard();
        }
    }
}
