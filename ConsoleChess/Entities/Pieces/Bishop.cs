using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "B";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Board board = chessMatch.Board;
            Movement.DiagonalMovement(possibleMoves, chessMatch, this);
            return possibleMoves;
        }
    }
}