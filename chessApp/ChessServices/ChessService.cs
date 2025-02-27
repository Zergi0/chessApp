using chessApp.Pieces;

namespace chessApp.ChessServices
{
    public class ChessService : IChessService
    {

        public List<BasePiece> Pieces { get; set; }

        public ChessService()
        {
            Pieces = [];
        }


        //creates a basic standard chess board
        public void CreateBaseBoard()
        {
            Pieces = new List<BasePiece>
{
             // Black Pieces
             new Rook(Colour.black, new Location('A', 8)),
             new Knight(Colour.black, new Location('B', 8)),
             new Bishop(Colour.black, new Location('C', 8)),
             new Queen(Colour.black, new Location('D', 8)),
             new King(Colour.black, new Location('E', 8)),
             new Bishop(Colour.black, new Location('F', 8)),
             new Knight(Colour.black, new Location('G', 8)),
             new Rook(Colour.black, new Location('H', 8)),
             new Pawn(Colour.black, new Location('A', 7)),
             new Pawn(Colour.black, new Location('B', 7)),
             new Pawn(Colour.black, new Location('C', 7)),
             new Pawn(Colour.black, new Location('D', 7)),
             new Pawn(Colour.black, new Location('E', 7)),
             new Pawn(Colour.black, new Location('F', 7)),
             new Pawn(Colour.black, new Location('G', 7)),
             new Pawn(Colour.black, new Location('H', 7)),

             // White Pieces
             new Rook(Colour.white, new Location('A', 1)),
             new Knight(Colour.white, new Location('B', 1)),
             new Bishop(Colour.white, new Location('C', 1)),
             new Queen(Colour.white, new Location('D', 1)),
             new King(Colour.white, new Location('E', 1)),
             new Bishop(Colour.white, new Location('F', 1)),
             new Knight(Colour.white, new Location('G', 1)),
             new Rook(Colour.white, new Location('H', 1)),
             new Pawn(Colour.white, new Location('A', 2)),
             new Pawn(Colour.white, new Location('B', 2)),
             new Pawn(Colour.white, new Location('C', 2)),
             new Pawn(Colour.white, new Location('D', 2)),
             new Pawn(Colour.white, new Location('E', 2)),
             new Pawn(Colour.white, new Location('F', 2)),
             new Pawn(Colour.white, new Location('G', 2)),
             new Pawn(Colour.white, new Location('H', 2))
            };

        }

        public BasePiece MovePiece(Location from, Location to)
        {
            try
            {
                var piece = IsThereAPieceAt(from);
                piece.MoveTo(to, Pieces);
                return piece;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private BasePiece IsThereAPieceAt(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location), "Location cannot be null.");
            }

            var piece = Pieces.FirstOrDefault(a => a.Location.X == location.X && a.Location.Y == location.Y);

            return piece == null ? throw new InvalidOperationException($"No piece found at {location.X}{location.Y}.") : piece;
        }


        public void CreateCustomBoard(List<PieceImport> pieceImports)
        {
            try
            {
                foreach (var import in pieceImports)
                {
                    BasePiece p = import.Type switch
                    {
                        "rook" => new Rook(import.Colour, import.Location),
                        "pawn" => new Pawn(import.Colour, import.Location),
                        "knight" => new Knight(import.Colour, import.Location),
                        "bishop" => new Bishop(import.Colour, import.Location),
                        "queen" => new Queen(import.Colour, import.Location),
                        "king" => new King(import.Colour, import.Location),
                        _ => throw new ArgumentException($"Unknown piece type: {import.Type}"),
                    };
                    if (!Pieces.Any(p => p.Location.X == import.Location.X && p.Location.Y == import.Location.Y))
                    {
                        Pieces.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EmptyTheBoard()
        {
            Pieces.Clear();
        }
    }
}
