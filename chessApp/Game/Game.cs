﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chessApp.Pieces;

namespace chessApp.Game
{
    public class Game : IGame
    {
        public List<BasePiece> Pieces { get; set; }

        public Game() 
        {
            Pieces = [];
        }

        
        public BasePiece MovePieceTo(Location from, Location to)
        {
            var piece = IsThereAPieceAt(from);
            piece.MoveTo(to,Pieces);
            return piece;
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

        //creates a basic standard chess board
        public void CreateBaseBoard()
        {
            Pieces = new List<BasePiece>
            {
               new Pawn(Colour.black, new Location('A', 7)),
               new Pawn(Colour.black, new Location('B', 7)),
               new Pawn(Colour.black, new Location('C', 7)),
               new Pawn(Colour.black, new Location('D', 7)),
               new Pawn(Colour.black, new Location('E', 7)),
               new Pawn(Colour.black, new Location('F', 7)),
               new Pawn(Colour.black, new Location('G', 7)),
               new Pawn(Colour.black, new Location('H', 7)),
               new Pawn(Colour.white, new Location('A', 2)),
               new Pawn(Colour.white, new Location('B', 2)),
               new Pawn(Colour.white, new Location('C', 2)),
               new Pawn(Colour.white, new Location('D', 2)),
               new Pawn(Colour.white, new Location('E', 2)),
               new Pawn(Colour.white, new Location('F', 2)),
               new Pawn(Colour.white, new Location('G', 2)),
               new Pawn(Colour.white, new Location('H', 2)),
            };
        }
        public void CreateCustomBoard(List<PieceImport> pieceImports)
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
                if (Pieces.Any(p => p.Location.X == import.Location.X && p.Location.Y == import.Location.Y))
                {
                    Pieces.Add(p);
                }
            }
        }
        public void EmptyTheBoard()
        {
            Pieces.Clear();
        }
    }
}
