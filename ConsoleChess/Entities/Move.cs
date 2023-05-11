using ConsoleChess.Entities.Pieces;

namespace ConsoleChess.Entities
{
    public class Move
    {
        private Piece StartPiece {get;}
        private Piece? FinalPiece {get;}

        public Move(Piece startPiece, Piece? finalPiece)
        {
            StartPiece = startPiece;
            FinalPiece = finalPiece;
        }
    }
}