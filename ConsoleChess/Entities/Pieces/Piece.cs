using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public abstract class Piece
    {
        public Color Color {get;}
        public Position CurrentPosition {get;}

        public Piece(Color color, Position currentPosition)
        {
            CurrentPosition = currentPosition;
            currentPosition.Piece = this;
            Color = color;
        }

        public abstract List<Move> GetMoves(Board board);
    }
}