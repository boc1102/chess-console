using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public abstract class Piece
    {
        public Color Color {get;}
        public Position CurrentPosition {get; internal set;}

        public Piece(Color color, Position currentPosition)
        {
            CurrentPosition = currentPosition;
            currentPosition.Piece = this;
            Color = color;
        }

        public abstract List<Move> GetMoves(ChessMatch chessMatch);
    }
}