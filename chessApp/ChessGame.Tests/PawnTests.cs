using chessApp.ChessServices;
using chessApp.Pieces;
using Xunit;

namespace ChessGame.Tests;

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
    [InlineData('A',3,Colour.white,'A',2)]
    [InlineData('A',4,Colour.white,'A',2)]
    [InlineData('A',6,Colour.black,'A',7)]
    [InlineData('A',5,Colour.black,'A',7)]
    [InlineData('A',4,Colour.white,'A',3)]
    [InlineData('A',4,Colour.black,'A',5)]
    public void MovePawnForward(char toX, int toY,Colour colour,char fromX, int fromY)
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
    [InlineData('C',3,Colour.white,'B',2,Colour.black)]
    [InlineData('A',3,Colour.white,'B',2,Colour.black)]
    [InlineData('A',6,Colour.black,'B',7,Colour.white)]
    [InlineData('C',6,Colour.black,'B',7,Colour.white)]
    public void MovePawnToTake(char toX, int toY, Colour colourSelf, char fromX, int fromY,Colour colourOpponent)
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
