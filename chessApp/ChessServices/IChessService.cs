using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public interface IChessService
    {
        void CreateNewBoard();
        List<BasePiece> GetPieces();
        BasePiece MovePiece(Location from, Location to);

    }
}
