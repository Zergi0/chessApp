namespace chessApp.Pieces
{
    public class Queen : BasePiece
    {
        public Queen(Colour colour, Location location) : base(colour, location)
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

                bool isDiagonal = Math.Abs(to.GetXAsNum() - Location.GetXAsNum()) == Math.Abs(to.Y - Location.Y);
                bool isStraight = Location.X == to.X || Location.Y == to.Y;

                if (!isDiagonal && !isStraight)
                {
                    throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }

                if (isDiagonal)
                {
                    int xDirection = (to.GetXAsNum() > Location.GetXAsNum()) ? 1 : -1;
                    int yDirection = (to.Y > Location.Y) ? 1 : -1;
                    int steps = Math.Abs(to.Y - Location.Y);

                    for (int i = 1; i < steps; i++)
                    {
                        var checkLocation = new Location((char)(Location.X + i * xDirection), Location.Y + i * yDirection);
                        if (pieces.Any(p => p.Location.X == checkLocation.X && p.Location.Y == checkLocation.Y))
                        {
                            throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                        }
                    }
                }
                else if (isStraight)
                {
                    if (pieces.Any(p =>
                        (Location.X == to.X && p.Location.X == Location.X && p.Location.Y > Math.Min(Location.Y, to.Y) && p.Location.Y < Math.Max(Location.Y, to.Y)) ||
                        (Location.Y == to.Y && p.Location.Y == Location.Y && p.Location.X > Math.Min(Location.GetXAsNum(), to.GetXAsNum()) && p.Location.X < Math.Max(Location.GetXAsNum(), to.GetXAsNum()))))
                    {
                        throw new InvalidOperationException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                    }
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
