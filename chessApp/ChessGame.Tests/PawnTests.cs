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

    [Fact]
    public void TestPawnMove1StepFromSpawnWhite()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn") };
        chessService.CreateCustomBoard(pieces);

        Location to = new Location('A', 3);
        chessService.MovePiece(pieces[0].Location, to);

        Location expected = new Location('A', 3);
        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
    }

    [Fact]
    public void TestPawnMove2StepFromSpawnWhite()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn") };
        chessService.CreateCustomBoard(pieces);

        Location to= new Location('A', 4);
        chessService.MovePiece(pieces[0].Location, to);

        Location expected = new Location('A', 4);
        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
    }

    [Fact]
    public void TestPawnMove1StepFromSpawnBlack()
    {
        List<PieceImport> pieces = new() { new(Colour.black, new Location('A', 7), "pawn") };
        chessService.CreateCustomBoard(pieces);

        Location to = new Location('A', 6);
        chessService.MovePiece(pieces[0].Location, to);

        Location expected = new Location('A', 6);
        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
    }

    [Fact]
    public void TestPawnMove2StepFromSpawnBlack()
    {
        List<PieceImport> pieces = new() { new(Colour.black, new Location('A', 7), "pawn") };
        chessService.CreateCustomBoard(pieces);

        Location to = new Location('A', 5);
        chessService.MovePiece(pieces[0].Location, to);

        Location expected = new Location('A', 5);
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

    [Fact]
    public void TestPawnTakeMoveOpponentPieceRightDirection()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('A', 2), "pawn"), new(Colour.black, new Location('B', 3), "pawn") };
        Location to = new Location('B', 3);
        chessService.CreateCustomBoard(pieces);


        chessService.MovePiece(pieces[0].Location, to);
        int expectedAmount = 1;
        Location expected = new Location('B', 3);

        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
        Assert.Equal(pieces.Count,expectedAmount);
    }


    [Fact]
    public void TestPawnTakeMoveOpponentPieceLeftDirection()
    {
        List<PieceImport> pieces = new() { new(Colour.white, new Location('B', 2), "pawn"), new(Colour.black, new Location('A', 3), "pawn") };
        Location to = new Location('A', 3);
        chessService.CreateCustomBoard(pieces);


        chessService.MovePiece(pieces[0].Location, to);
        int expectedAmount = 1;
        Location expected = new Location('A', 3);

        Assert.Equal(expected.ToString(), chessService.Pieces[0].Location.ToString());
        Assert.Equal(pieces.Count, expectedAmount);
    }

}
