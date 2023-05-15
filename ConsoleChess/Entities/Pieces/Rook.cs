using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "R";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            throw new NotImplementedException();
        }
    }
}