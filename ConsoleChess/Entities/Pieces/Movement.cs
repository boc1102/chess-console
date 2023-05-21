

namespace ConsoleChess.Entities.Pieces
{
    public static class Movement
    {
        public static bool CheckMove(Position position, Piece piece)
        {
            if(position.Piece != null)
                if(position.Piece.Color == piece.Color)
                {
                    return false;
                }
            return true;
        }
        public static List<Move> KnightMovement(List<Move> possibleMoves, Board board, Piece piece)
        {
            int line = piece.CurrentPosition.Line;
            int column = piece.CurrentPosition.Column;

            try
            {
                Position frontShortRightPosition = board.Positions[line - 1, column + 2];
                if(CheckMove(frontShortRightPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, frontShortRightPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontShortLeftPosition = board.Positions[line - 1, column - 2];
                if(CheckMove(frontShortLeftPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, frontShortLeftPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontLongRightPosition = board.Positions[line - 2, column + 1];
                if(CheckMove(frontLongRightPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, frontLongRightPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontLongLeftPosition = board.Positions[line - 2, column - 1];
                if(CheckMove(frontLongLeftPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, frontLongLeftPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backShortRightPosition = board.Positions[line + 1, column + 2];
                if(CheckMove(backShortRightPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, backShortRightPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backShortLeftPosition = board.Positions[line + 1, column - 2];
                if(CheckMove(backShortLeftPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, backShortLeftPosition));
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backLongRightPosition = board.Positions[line + 2, column + 1];
                if(CheckMove(backLongRightPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, backLongRightPosition));
            }
            catch(IndexOutOfRangeException){}
            
            try
            {
                Position backLongLeftPosition = board.Positions[line + 2, column - 1];
                if(CheckMove(backLongLeftPosition, piece))
                    possibleMoves.Add(new Move(piece.CurrentPosition, backLongLeftPosition));
            }
            catch(IndexOutOfRangeException){}
            
            return possibleMoves;
        }
    }
}