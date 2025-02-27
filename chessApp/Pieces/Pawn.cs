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
                int direction = (Colour == Colour.white) ? 1 : -1;
                Console.WriteLine(Location.X + " " + to.X + " " + Location.GetXAsNum() + 1);

                Console.WriteLine(IsThatTakenByOppositeColour(to, pieces, Colour) + " isThatTaken? " + to);
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
                    pieces.Remove(piece);
                    Location = to;
                }
                else
                {
                    throw new InvalidDataException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
                }
            }
            catch (InvalidDataException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new InvalidDataException($"Cannot make move to {to.X}{to.Y} from {Location.X}{Location.Y}.");
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
