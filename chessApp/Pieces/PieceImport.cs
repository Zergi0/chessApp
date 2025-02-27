namespace chessApp.Pieces
{
    public class PieceImport
    {
        public Colour Colour { get; set; }
        public required Location Location { get; set; }
        public required string Type { get; set; }
    }
}
