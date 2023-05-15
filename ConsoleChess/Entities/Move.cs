using ConsoleChess.Entities.Pieces;

namespace ConsoleChess.Entities
{
    public class Move
    {
        public Position StartPosition {get;}
        public Position FinalPosition {get;}

        public Move(Position startPosition, Position finalPosition)
        {
            StartPosition = startPosition;
            FinalPosition = finalPosition;
        }

        public void Execute()
        {
            FinalPosition.Piece = StartPosition.Piece;
            StartPosition.Piece = null;
        }

        public override string ToString()
        {
            return $"{StartPosition} -> {FinalPosition}";
        }
    }
}