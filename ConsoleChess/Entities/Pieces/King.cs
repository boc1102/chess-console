using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "K";
        }
    }
}