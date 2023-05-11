using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Position currentPosition) : base(color, currentPosition){}

        public override string ToString()
        {
            return "P";
        }
    }
}