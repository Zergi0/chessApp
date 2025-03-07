namespace chessApp.Pieces
{
    public class PieceImport
    {
        public Colour Colour { get; set; }
        public Location Location { get; set; }
        public  string Type { get; set; }

        public PieceImport(Colour colour, Location location, string type)
        {
            Colour = colour;
            Location = location;
            Type = type;
        }
    }
}
