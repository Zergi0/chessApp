using chessApp.ChessServices;
using chessApp.Pieces;
using Xunit;

namespace chessApp.ChessGame.Tests
{
    public class RookTests : IDisposable
    {
        private ChessService chessService;

        public RookTests()
        {
            this.chessService = new ChessService();
        }

        public void Dispose()
        {
            chessService.EmptyTheBoard();
        }

        [Theory]
        [InlineData('D', 5, 'D', 8)]
        [InlineData('D', 5, 'D', 6)]
        [InlineData('D', 5, 'D', 1)]
        [InlineData('D', 5, 'D', 4)]
        [InlineData('D', 5, 'E', 5)]
        [InlineData('D', 5, 'C', 5)]
        [InlineData('D', 5, 'H', 5)]
        [InlineData('D', 5, 'A', 5)]
        public void MoveToUnoccupied(char fromX, int fromY, char toX, int toY)
        {
            List<PieceImport> pieces = new() { new(Colour.white, new Location(fromX, fromY), "rook") };
            Location to = new Location(toX, toY);
            chessService.CreateCustomBoard(pieces);

            chessService.MovePiece(pieces[0].Location, to);
            Location expected = new Location(toX, toY);

            Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
        }

        [Theory]
        [InlineData('D', 5, 'D', 8, Colour.white, Colour.black)]
        [InlineData('D', 5, 'D', 6, Colour.white, Colour.black)]
        [InlineData('D', 5, 'D', 1, Colour.white, Colour.black)]
        [InlineData('D', 5, 'D', 4, Colour.white, Colour.black)]
        [InlineData('D', 5, 'E', 5, Colour.white, Colour.black)]
        [InlineData('D', 5, 'C', 5, Colour.white, Colour.black)]
        [InlineData('D', 5, 'H', 5, Colour.white, Colour.black)]
        [InlineData('D', 5, 'A', 5, Colour.white, Colour.black)]
        public void TakeOpponentPiece(char fromX, int fromY, char toX, int toY, Colour colourSelf, Colour colourOpponent)
        {
            List<PieceImport> pieces = new() { new(colourSelf, new Location(fromX, fromY), "rook"), new(colourOpponent, new Location(toX,toY),"pawn") };
            Location to = new Location(toX, toY);
            chessService.CreateCustomBoard(pieces);

            chessService.MovePiece(pieces[0].Location, to);
            Location expected = new Location(toX, toY);
            int expectedAmount = 1;


            Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
            Assert.Equal(expectedAmount,chessService.Pieces.Count);
        }

        [Theory]
        [InlineData('D', 5, 'D', 8, 'D', 6, Colour.white, Colour.black)]
        [InlineData('D', 5, 'D', 8, 'D', 6, Colour.black, Colour.white)]
        [InlineData('D', 5, 'D', 1, 'D', 4, Colour.white, Colour.black)]
        [InlineData('D', 5, 'D', 1, 'D', 4, Colour.black, Colour.white)]
        [InlineData('D', 5, 'H', 5, 'E', 5, Colour.white, Colour.black)]
        [InlineData('D', 5, 'H', 5, 'E', 5, Colour.black, Colour.white)]
        [InlineData('D', 5, 'A', 5, 'C', 5, Colour.white, Colour.black)]
        [InlineData('D', 5, 'A', 5, 'C', 5, Colour.black, Colour.white)]
        public void TryAndStepOverPiece_ShouldThrowInvalidOperationException(char fromX, int fromY, char toX, int toY,char additionalPieceX, int additionalPieceY, Colour colourSelf, Colour colourOpponent)
        {
            List<PieceImport> pieces = new() { new(colourSelf, new Location(fromX, fromY), "rook"), new(colourOpponent, new Location(additionalPieceX, additionalPieceY), "pawn") };
            Location to = new Location(toX, toY);
            chessService.CreateCustomBoard(pieces);

            var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

            Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);

        }

        [Theory]
        [InlineData('D', 5, 'D', 8, Colour.white)]
        [InlineData('D', 5, 'D', 6, Colour.white)]
        [InlineData('D', 5, 'D', 1, Colour.white)]
        [InlineData('D', 5, 'D', 4, Colour.white)]
        [InlineData('D', 5, 'E', 5, Colour.white)]
        [InlineData('D', 5, 'C', 5, Colour.white)]
        [InlineData('D', 5, 'H', 5, Colour.white)]
        [InlineData('D', 5, 'A', 5, Colour.white)]
        public void TryAndTakeAllyPiece_ShouldThrowInvalidOperationException(char fromX, int fromY, char toX, int toY, Colour colourSelf)
        {
            List<PieceImport> pieces = new() { new(colourSelf, new Location(fromX, fromY), "rook"), new(colourSelf, new Location(toX, toY), "pawn") };
            Location to = new Location(toX, toY);
            chessService.CreateCustomBoard(pieces);

            var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

            Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);

        }
    }
}
