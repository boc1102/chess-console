using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "N";
        }

        public override List<Move> GetMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}