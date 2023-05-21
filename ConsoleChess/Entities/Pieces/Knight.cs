using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "N";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Board board = chessMatch.Board;
            return Movement.KnightMovement(possibleMoves, board, this);
        }
    }
}