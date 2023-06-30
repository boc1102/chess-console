using ConsoleChess.Entities.Pieces;

namespace ConsoleChess.Entities
{
    public class Move
    {
        public Position StartPosition {get;}
        public Position FinalPosition {get;}
        public Piece? StartingPiece {get;}
        public Piece? FinalPiece {get;}
        public Position? EnPassant {get;}
        public Move? Castle {get;}

        public Move(Position startPosition, Position finalPosition,
            Position? enPassant = null, Move? castle = null)
        {
            StartPosition = startPosition;
            StartingPiece = startPosition.Piece;
            FinalPosition = finalPosition;
            FinalPiece = finalPosition.Piece;
            EnPassant = enPassant;
            Castle = castle;
        }

        public bool Execute()
        {
            StartingPiece!.CurrentPosition = FinalPosition;
            FinalPosition.Piece = StartPosition.Piece;
            StartPosition.Piece = null;
            if(EnPassant != null) EnPassant.Piece = null;
            if(Castle != null) Castle.Execute();
            return true;
        }

        public void Reverse()
        {
            StartingPiece!.CurrentPosition = StartPosition;
            StartPosition.Piece = StartingPiece;
            if(FinalPiece != null) FinalPiece.CurrentPosition = FinalPosition;
            FinalPosition.Piece = FinalPiece;
        }

        public override string ToString()
        {
            return $"{StartPosition} -> {FinalPosition}";
        }
    }
}