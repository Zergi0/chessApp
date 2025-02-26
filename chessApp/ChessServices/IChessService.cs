using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public interface IChessService
    {
        void CreateNewBoard();

        void CreateCustomBoard(List<PieceImport> pieceImports);

        void EmptyTheBoard();
        List<BasePiece> GetPieces();
        BasePiece MovePiece(Location from, Location to);

    }
}
