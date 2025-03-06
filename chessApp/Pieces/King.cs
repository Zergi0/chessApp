
namespace chessApp.Pieces
{
    public class King : BasePiece
    {
        public King(Colour colour, Location location) : base(colour, location)
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
                else if (to.GetXAsNum() - Location.GetXAsNum() == 0 && to.Y - Location.Y == 0)
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
                else if (Math.Abs(to.GetXAsNum() - Location.GetXAsNum()) <= 1 && Math.Abs(to.Y - Location.Y) <= 1)
                {

                     //remove and move
                     var piece = pieces.FirstOrDefault(p => p.Location.X == to.X && p.Location.Y == to.Y && p.Colour != Colour);
                     if (piece != null)
                     {
                         pieces.Remove(piece);
                     }
                     Location = to;
                } else
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
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
