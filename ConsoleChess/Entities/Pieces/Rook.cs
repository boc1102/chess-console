using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "R";
        }

        public override List<Move> GetMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}