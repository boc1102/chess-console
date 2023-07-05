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
        public Piece? EnPassantPiece {get;}
        public Move? Castle {get;}

        public Move(Position startPosition, Position finalPosition,
            Position? enPassant = null, Move? castle = null)
        {
            StartPosition = startPosition;
            StartingPiece = startPosition.Piece;
            FinalPosition = finalPosition;
            FinalPiece = finalPosition.Piece;
            EnPassant = enPassant;
            if(enPassant != null) EnPassantPiece = enPassant.Piece;
            Castle = castle;
        }

        public void Execute()
        {
            StartingPiece!.CurrentPosition = FinalPosition;
            FinalPosition.Piece = StartPosition.Piece;
            StartPosition.Piece = null;
            if(EnPassant != null) EnPassant.Piece = null;
            if(Castle != null) Castle.Execute();
        }

        public void Reverse()
        {
            StartingPiece!.CurrentPosition = StartPosition;
            StartPosition.Piece = StartingPiece;
            if(FinalPiece != null) FinalPiece.CurrentPosition = FinalPosition;
            FinalPosition.Piece = FinalPiece;
            if(Castle != null) Castle.Reverse();
            if(EnPassantPiece != null)
            {
                EnPassant!.Piece = EnPassantPiece;
                EnPassantPiece.CurrentPosition = EnPassant;
            }
        }

        public override string ToString()
        {
            return $"{StartPosition} -> {FinalPosition}";
        }
    }
}