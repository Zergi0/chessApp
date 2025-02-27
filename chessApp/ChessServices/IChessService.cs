using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public interface IChessService
    {
        List<BasePiece> Pieces { get; }
        void CreateBaseBoard();

        void CreateCustomBoard(List<PieceImport> pieceImports);

        void EmptyTheBoard();

        BasePiece MovePiece(Location from, Location to);

    }
}
