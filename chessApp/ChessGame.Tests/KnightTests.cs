using chessApp.ChessServices;
using chessApp.Pieces;
using Xunit;

namespace chessApp.ChessGame.Tests
{
    public class KnightTests : IDisposable
    {
        private ChessService chessService;

        public KnightTests()
        {
            this.chessService = new ChessService();
        }
        public void Dispose()
        {
            chessService.EmptyTheBoard();
        }

        [Theory]
        [InlineData('B',5)]
        [InlineData('B', 3)]
        [InlineData('C', 6)]
        [InlineData('C', 2)]
        [InlineData('E', 6)]
        [InlineData('E', 2)]
        [InlineData('F', 5)]
        [InlineData('F', 3)]
        public void MoveToPossibleSquares(char toX, int toY)
        {

            List<PieceImport> pieces = new() { new(Colour.white, new Location('D', 4), "knight")};
            Location to = new Location(toX,toY);
            chessService.CreateCustomBoard(pieces);

            chessService.MovePiece(pieces[0].Location,to);
            Location expected = new Location(toX,toY);

            Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
        }

        [Theory]
        [InlineData('I',3)]
        [InlineData('I',-1)]
        [InlineData('J',2)]
        [InlineData('J',0)]
        public void MoveOutOfBounds_ShouldThrowInvalidOperationException(char toX, int toY)
        {
            List<PieceImport> pieces = new() { new(Colour.white, new Location('D', 4), "knight") };
            Location to = new Location(toX, toY);
            chessService.CreateCustomBoard(pieces);

            var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

            Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
        }

        [Fact]
        public void MoveAndTake()
        {
            List<PieceImport> pieces = new() { new(Colour.white, new Location('D', 4), "knight"), new(Colour.black, new Location('B', 5), "pawn")};
            Location to = new Location('B', 5);
            chessService.CreateCustomBoard(pieces);

            chessService.MovePiece(pieces[0].Location, to);
            int expectedAmount = 1;
            Location expected = new Location('B', 5);

            Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
            Assert.Equal(chessService.Pieces.Count, expectedAmount);
        }
        [Fact]
        public void MoveAndTakeAndBreak_ShouldThrowInvalidOperationException()
        {
            List<PieceImport> pieces = new() { new(Colour.white, new Location('D', 4), "knight"), new(Colour.white, new Location('B', 5), "pawn") };
            Location to = new Location('B', 5);
            chessService.CreateCustomBoard(pieces);

            var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

            Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
        }

    }
}
