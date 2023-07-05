using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "Q";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Board board = chessMatch.Board;
            Movement.HorizontalMovement(possibleMoves, chessMatch, this);
            Movement.DiagonalMovement(possibleMoves, chessMatch, this);
            return possibleMoves;
        }
    }
}