namespace chessApp.Pieces
{
    class Pawn : BasePiece
    {
        public Pawn(Colour Colour, Location location) : base(Colour, location)
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
                int direction = (Colour == Colour.white) ? 1 : -1;

                //1 step forward
                if (Location.Y + direction == to.Y && IsThatEmpty(to, pieces))
                {
                    Location = to;
                }
                //2 steps forward from starting location
                else if (Location.Y + (2 * direction) == to.Y && IsThatEmpty(to, pieces) && isAtStartingLocation())
                {
                    Location = to;
                }
                //take something
                else if (Location.Y + direction == to.Y &&
                    (Location.GetXAsNum() + 1 == to.GetXAsNum() || Location.GetXAsNum() - 1 == to.GetXAsNum())
                    && IsThatTakenByOppositeColour(to, pieces, Colour))
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
            catch (Exception)
            {
                throw new InvalidDataException("Unknown error.");
            }

        }
        private bool isAtStartingLocation()
        {
            if ((Location.Y == 2 && Colour == Colour.white) ||
                (Location.Y == 7 && Colour == Colour.black))
            {
                return true;
            }
            return false;
        }
        private bool IsThatEmpty(Location at, List<BasePiece> pieces)
        {
            return !pieces.Any(p => p.Location.X == at.X && p.Location.Y == at.Y);
        }
        private bool IsThatTakenByOppositeColour(Location at, List<BasePiece> pieces, Colour myColour)
        {
            return pieces.Any(p => p.Location.X == at.X && p.Location.Y == at.Y && p.Colour != myColour);
        }
    }

}
