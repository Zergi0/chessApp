
namespace chessApp.Pieces
{
    public class Rook : BasePiece
    {
        public Rook(Colour colour, Location location) : base(colour, location)
        {
        }

        public override void MoveTo(Location to, List<BasePiece> pieces)
        {
            //can only move up or down or sideways, any number of squares but not both
            if((Location.X == to.X && Location.Y == to.Y) || (Location.X != to.X && Location.Y != to.Y))
            {
                throw new Exception();
            }
            if (Location.X == to.X && Location.Y != to.Y)
            {
                var difference = Location.Y - to.Y; 
            }
            if (Location.X != to.X && Location.Y == to.Y)
            {

            }

        }
    }
}
