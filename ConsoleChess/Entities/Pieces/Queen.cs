using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "Q";
        }

        public override List<Move> GetMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}