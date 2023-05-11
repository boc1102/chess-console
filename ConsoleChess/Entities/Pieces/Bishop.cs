using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "B";
        }
    }
}