using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class Rook : Piece
    {
        public bool Moved {get; internal set;}
        public Rook(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "R";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Board board = chessMatch.Board;
            Movement.HorizontalMovement(possibleMoves, board, this);
            return possibleMoves;
        }
    }
}