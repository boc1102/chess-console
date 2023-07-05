using ConsoleChess.Entities.Pieces;

namespace ConsoleChess.Exceptions
{
    public class PromotionException : ApplicationException
    {
        public Piece Piece;
        public PromotionException(string message, Piece piece) : base(message)
        {
            Piece = piece;
        }
    }
}