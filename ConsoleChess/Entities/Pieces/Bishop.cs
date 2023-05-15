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
            throw new NotImplementedException();
        }
    }
}