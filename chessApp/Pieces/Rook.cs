
namespace chessApp.Pieces
{
    public class Rook : BasePiece
    {
        public Rook(Colour colour, Location location) : base(colour, location)
        {
        }

        public override void MoveTo(Location to, List<BasePiece> pieces)
        {
            try
            {

                if (pieces.Any(p => p.Location.X == Location.X && p.Location.Y == Location.Y && p.Colour == Colour))
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
                //can only move up or down or sideways, any number of squares but not both
                if ((Location.X == to.X && Location.Y == to.Y) || (Location.X != to.X && Location.Y != to.Y))
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
                else if (pieces.Any(p =>
                    (Location.X == to.X && p.Location.X == Location.X &&
                     p.Location.Y > Math.Min(Location.Y, to.Y) &&
                     p.Location.Y < Math.Max(Location.Y, to.Y)) ||
                    (Location.Y == to.Y && p.Location.Y == Location.Y &&
                     p.Location.X > Math.Min(Location.GetXAsNum(), to.GetXAsNum()) &&
                     p.Location.X < Math.Max(Location.GetXAsNum(), to.GetXAsNum()))))
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
               
                var piece = pieces.FirstOrDefault(p => p.Location.X == to.X && p.Location.Y == to.Y && p.Colour != Colour);
                if (piece != null)
                {
                    pieces.Remove(piece);
                }
                Location = to;
                
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new InvalidDataException("Unknown error.");
            }
        }
    }
}
