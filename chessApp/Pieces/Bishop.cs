namespace chessApp.Pieces
{
    public class Bishop : BasePiece
    {
        public Bishop(Colour colour, Location location) : base(colour, location)
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

                if (Math.Abs(to.GetXAsNum() - Location.GetXAsNum()) != Math.Abs(to.Y - Location.Y))
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
                int xDirection = (to.GetXAsNum() > Location.GetXAsNum()) ? 1 : -1;  // Right or Left
                int yDirection = (to.Y > Location.Y) ? 1 : -1;  // Up or Down

                int steps = (Math.Abs(to.Y - Location.Y));

                for (int i = 1; i < steps; i++)
                {
                    var checkLocation = new Location((char)(Location.X + i * xDirection), Location.Y + i * yDirection);
                    if (pieces.Any(p => p.Location.X == checkLocation.X && p.Location.Y == checkLocation.Y))
                    {
                        throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                    }
                }

                //remove and move
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
