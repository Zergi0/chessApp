using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public interface IChessService
    {
        public void CreateNewBoard();
        List<BasePiece> GetPieces();
    }
}
