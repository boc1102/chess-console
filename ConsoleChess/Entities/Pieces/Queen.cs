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
            throw new NotImplementedException();
        }
    }
}