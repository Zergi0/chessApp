
namespace chessApp.Pieces
{
    public class Knight : BasePiece
    {
        public Knight(Colour colour, Location location) : base(colour, location)
        {
        }

        public override void MoveTo(Location to, List<BasePiece> pieces)
        {
            try
            {

                if (pieces.Any(p => p.Location.X == to.X && p.Location.Y == to.Y && p.Colour == Colour))
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
                int deltaY = Math.Abs(Location.Y - to.Y);
                int deltaX = Math.Abs(Location.GetXAsNum() - to.GetXAsNum());
                if ((deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2))
                {
                    var piece = pieces.FirstOrDefault(p => p.Location.X == to.X && p.Location.Y == to.Y && p.Colour != Colour);
                    if (piece != null)
                    {
                        pieces.Remove(piece);
                    }
                    Location = to;
                }
                else
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidDataException($"Unknown error.{e}");
            }
        }
    }
}
