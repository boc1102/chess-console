using ConsoleChess.Game;

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
        public static void KnightMovement(List<Move> possibleMoves, ChessMatch chessMatch,
            Piece piece, bool verifying = false)
        {
            King king = chessMatch.Kings[chessMatch.TurnColor];
            Board board = chessMatch.Board;

            int line = piece.CurrentPosition.Line;
            int column = piece.CurrentPosition.Column;

            try
            {
                Position frontShortRightPosition = board.Positions[line - 1, column + 2];
                if(CheckMove(frontShortRightPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, frontShortRightPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontShortLeftPosition = board.Positions[line - 1, column - 2];
                if(CheckMove(frontShortLeftPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, frontShortLeftPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontLongRightPosition = board.Positions[line - 2, column + 1];
                if(CheckMove(frontLongRightPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, frontLongRightPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position frontLongLeftPosition = board.Positions[line - 2, column - 1];
                if(CheckMove(frontLongLeftPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, frontLongLeftPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backShortRightPosition = board.Positions[line + 1, column + 2];
                if(CheckMove(backShortRightPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, backShortRightPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backShortLeftPosition = board.Positions[line + 1, column - 2];
                if(CheckMove(backShortLeftPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, backShortLeftPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position backLongRightPosition = board.Positions[line + 2, column + 1];
                if(CheckMove(backLongRightPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, backLongRightPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}
            
            try
            {
                Position backLongLeftPosition = board.Positions[line + 2, column - 1];
                if(CheckMove(backLongLeftPosition, piece))
                {
                    Move move = new Move(piece.CurrentPosition, backLongLeftPosition);
                    if(verifying) possibleMoves.Add(move);
                    else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                }
            }
            catch(IndexOutOfRangeException){}
        }
    
        public static void DiagonalMovement(List<Move> possibleMoves, ChessMatch chessMatch,
            Piece piece, bool verifying = false)
        {
            King king = chessMatch.Kings[chessMatch.TurnColor];
            Board board = chessMatch.Board;

            int size = board.Positions.Length;
            int line = piece.CurrentPosition.Line;
            int column = piece.CurrentPosition.Column;

            // Top-right diagonal:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line - i, column + i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Top-left diagonal:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line - i, column - i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Bottom-right diagonal:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line + i, column + i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Bottom-left diagonal:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line + i, column - i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}
        }
    
        public static void HorizontalMovement(List<Move> possibleMoves, ChessMatch chessMatch,
        Piece piece, bool verifying = false)
        {
            King king = chessMatch.Kings[chessMatch.TurnColor];
            Board board = chessMatch.Board;

            int size = board.Positions.Length;
            int line = piece.CurrentPosition.Line;
            int column = piece.CurrentPosition.Column;

            // Left:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line, column - i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Right:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line, column + i];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Up:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line - i, column];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}

            // Down:
            try
            {
                for(int i = 1; i < size; i++)
                {
                    Position pos = board.Positions[line + i, column];
                    if(CheckMove(pos, piece))
                    {
                        Move move = new Move(piece.CurrentPosition, pos);
                        if(verifying) possibleMoves.Add(move);
                        else if(!king.VerifyCheck(chessMatch, move)) possibleMoves.Add(move);
                    }
                    if(pos.Piece != null) break;
                }
            }catch(IndexOutOfRangeException){}
        }
    }
}