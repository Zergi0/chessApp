using chessApp.ChessServices;
using chessApp.Pieces;
using Xunit;

namespace chessApp.ChessGame.Tests;

public class PawnTests : IDisposable
{
    private ChessService chessService;

    public PawnTests()
    {
        this.chessService = new ChessService();
    }
    public void Dispose()
    {
        chessService.EmptyTheBoard();
    }

    [Theory]
    [InlineData('A', 2, Colour.white, 'A', 3)]
    [InlineData('A', 2, Colour.white, 'A', 4)]
    [InlineData('A', 7, Colour.black, 'A', 6)]
    [InlineData('A', 7, Colour.black, 'A', 5)]
    [InlineData('A', 3, Colour.white, 'A', 4)]
    [InlineData('A', 5, Colour.black, 'A', 4)]
    public void MovePawnForward(char fromX, int fromY, Colour colour, char toX, int toY)
    {
        List<PieceImport> pieces = new() { new(colour, new Location(fromX,fromY), "pawn") };
        chessService.CreateCustomBoard(pieces);


        Location to = new Location(toX,toY);
        chessService.MovePiece(pieces[0].Location, to);

        Location expected = new Location(toX, toY);
        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
    }

    [Fact]
    public void TestPawnMoveStepOnAnotherPiece_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn"), new(Colour.white, new Location('A', 3), "pawn") };
        Location to = new Location('A', 3);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }

    [Fact]
    public void TestPawnMoveStepOverAnotherPiece_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn"), new(Colour.white, new Location('A', 3), "pawn") };
        Location to = new Location('A', 4);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }
    [Fact]
    public void TestPawnMoveStepOnOpponentPiece_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn"), new(Colour.black, new Location('A', 3), "pawn") };
        Location to = new Location('A', 3);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }

    [Fact]
    public void TestPawnTakeMoveAllyPiece_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn"), new(Colour.white, new Location('B', 3), "pawn") };
        Location to = new Location('B', 3);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }
    [Fact]
    public void TestPawnTakeMoveToNothing_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn")};
        Location to = new Location('B', 3);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }


    [Theory]
    [InlineData('B', 2, Colour.black, 'C', 3, Colour.white)]
    [InlineData('B', 2, Colour.black, 'A', 3, Colour.white)]
    [InlineData('B', 7, Colour.white, 'A', 6, Colour.black)]
    [InlineData('B', 7, Colour.white, 'C', 6, Colour.black)]
    public void MovePawnToTake(char fromX, int fromY, Colour colourSelf, char toX, int toY, Colour colourOpponent)
    {
        List<PieceImport> pieces = new() { new(colourSelf, new Location(fromX,fromY), "pawn"), new(colourOpponent, new Location(toX,toY), "pawn") };
        Location to = new Location(toX,toY);
        chessService.CreateCustomBoard(pieces);

        chessService.MovePiece(pieces[0].Location, to);
        int expectedAmount = 1;
        Location expected = new Location(toX, toY);


        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
        Assert.Equal(chessService.Pieces.Count, expectedAmount);
    }
    [Fact]
    public void MovePawnToTakeWrongDirection_ShouldThrowInvalidOperationException()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 3), "pawn"), new(Colour.black, new Location('B', 2), "pawn") };
        Location to = new Location('B', 2);
        chessService.CreateCustomBoard(pieces);

        var exception = Assert.Throws<InvalidOperationException>(() => chessService.MovePiece(pieces[0].Location, to));

        Assert.Equal($"Cannot make move to {to.X}{to.Y} from {pieces[0].Location.X}{pieces[0].Location.Y}.", exception.Message);
    }
}
