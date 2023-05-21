using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Color color, Position currentPosition) : base(color, currentPosition){}

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();



            return possibleMoves;
        }

        public bool VerifyCheck()
        {
            return false;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}