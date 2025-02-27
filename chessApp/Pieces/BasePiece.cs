namespace chessApp.Pieces
{
    public abstract class BasePiece
    {
        public virtual void MoveTo(Location to, List<BasePiece> pieces)
        {
            Location = to;
        }
        public Colour Colour { get; set; }
        public Location Location { get; set; }


        public BasePiece(Colour colour, Location location)
        {
            Colour = colour;
            Location = location;
        }
    }
}
