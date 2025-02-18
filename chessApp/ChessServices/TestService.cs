using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public class TestService : ITestService
    {
        public List<BasePiece> GetData()
        {
            return new List<BasePiece>
            {
                new Pawn("black", new Location('A', 2)),
                new Pawn("black", new Location('B', 2)),
                new Pawn("black", new Location('C', 3)),
            };
        }
    }

}
