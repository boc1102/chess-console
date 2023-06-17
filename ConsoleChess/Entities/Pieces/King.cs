using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Color color, Position currentPosition) : base(color, currentPosition){}

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Position[,] positions = chessMatch.Board.Positions;
            int line = CurrentPosition.Line;
            int column = CurrentPosition.Column;

            try
            {
                Position position = positions[line - 1, column - 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line - 1, column];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line - 1, column + 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line, column - 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line, column + 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column - 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column + 1];
                if(Movement.CheckMove(position, this)) possibleMoves.Add(new Move(CurrentPosition, position));
            }catch(IndexOutOfRangeException){}

            return possibleMoves;
        }

        public bool VerifyCheck(Board board)
        {
            // Checking for knights:
            List<Move> moves = new List<Move>();
            Movement.KnightMovement(moves, board, this);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Knight knight)
                {
                    if(knight.Color != Color) return true;
                }
            }

            // Checking for diagonal (queens and bishops):
            moves = new List<Move>();
            Movement.DiagonalMovement(moves, board, this);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Bishop bishop)
                {
                    if(bishop.Color != Color) return true;
                }
                if(finalPiece is Queen queen)
                {
                    if(queen.Color != Color) return true;
                }
            }

            // Checking for horizontal (queens and rooks):
            moves = new List<Move>();
            Movement.HorizontalMovement(moves, board, this);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Rook rook)
                {
                    if(rook.Color != Color) return true;
                }
                if(finalPiece is Queen queen)
                {
                    if(queen.Color != Color) return true;
                }
            }

            // Checking for pawns:
            moves = new List<Move>();
            int line = CurrentPosition.Line;
            int column = CurrentPosition.Column;

            try
            {
                moves.Add(new Move(CurrentPosition, board.Positions[line + (int)Color, column + 1]));
            }catch(IndexOutOfRangeException){}

            try
            {
                moves.Add(new Move(CurrentPosition, board.Positions[line + (int)Color, column - 1]));
            }catch(IndexOutOfRangeException){}
            
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Pawn pawn)
                {
                    if(pawn.Color != Color) return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}