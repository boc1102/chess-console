using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "K";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            throw new NotImplementedException();
        }
    }
}