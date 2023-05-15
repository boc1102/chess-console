using ConsoleChess.Entities.Pieces;

namespace ConsoleChess.Entities
{
    public class Move
    {
        public Position StartPosition {get;}
        public Position FinalPosition {get;}
        public Position? EnPassant {get;}

        public Move(Position startPosition, Position finalPosition, Position? enPassant = null)
        {
            StartPosition = startPosition;
            FinalPosition = finalPosition;
            EnPassant = enPassant;
        }

        public bool Execute()
        {
            StartPosition.Piece!.CurrentPosition = FinalPosition;
            FinalPosition.Piece = StartPosition.Piece;
            StartPosition.Piece = null;
            if(EnPassant != null)
            {
                EnPassant.Piece = null;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{StartPosition} -> {FinalPosition}";
        }
    }
}