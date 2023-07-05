using ConsoleChess.Exceptions;
using ConsoleChess.Entities.Enums;
using ConsoleChess.Game;

namespace ConsoleChess.Entities.Pieces
{
    public class King : Piece
    {
        public bool Moved{get; internal set;}
        public bool Checked{get; internal set;}
        public King(Color color, Position currentPosition) : base(color, currentPosition)
        {
            Moved = false;
            Checked = false;
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            List<Move> possibleMoves = new List<Move>();
            Position[,] positions = chessMatch.Board.Positions;
            int line = CurrentPosition.Line;
            int column = CurrentPosition.Column;

            try
            {
                Position position = positions[line - 1, column - 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line - 1, column];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line - 1, column + 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line, column - 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line, column + 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column - 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}
            try
            {
                Position position = positions[line + 1, column + 1];
                if(Movement.CheckMove(position, this))
                {
                    Move move = new Move(CurrentPosition, position);
                    if(!VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }catch(IndexOutOfRangeException){}

            // Castling (first check):
            if(!Moved)
            {
                // Castling left:
                try
                {
                    Position position = positions[line, 0];
                    if(position.Piece is Rook {Moved: false})
                    {
                        bool failed = false;
                        for(int col = column - 1; col > 0; col--)
                        {
                            Position midPosition = positions[line, col];
                            if(midPosition.Piece != null) failed = true;
                        }
                        if(!failed)
                        {
                            Move move = new Move(CurrentPosition, positions[line, 1],
                                castle: new Move(position, positions[line, 2]));
                            if(!VerifyCheck(chessMatch, move))
                                possibleMoves.Add(move);
                        }
                    }
                }catch(IndexOutOfRangeException){}
                // Castling right:
                try
                {
                    Position position = positions[line, 7];
                    if(position.Piece is Rook {Moved: false})
                    {
                        bool failed = false;
                        for(int col = column + 1; col < 7; col++)
                        {
                            Position midPosition = positions[line, col];
                            if(midPosition.Piece != null) failed = true;
                        }
                        if(!failed)
                        {
                            Move move = new Move(CurrentPosition, positions[line, 6],
                                castle: new Move(position, positions[line, 5]));
                            if(!VerifyCheck(chessMatch, move))
                                possibleMoves.Add(move);
                        }
                    }
                }catch(IndexOutOfRangeException){}
            }
            

            return possibleMoves;
        }

        public bool VerifyCheck(ChessMatch chessMatch, Move? possibleCheck = null)
        {
            Board board = chessMatch.Board;

            if(possibleCheck != null) possibleCheck.Execute();

            // Checking for knights:
            List<Move> moves = new List<Move>();
            Movement.KnightMovement(moves, chessMatch, this, true);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Knight knight)
                {
                    if(knight.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
                }
            }

            // Checking for diagonal (queens and bishops):
            moves = new List<Move>();
            Movement.DiagonalMovement(moves, chessMatch, this, true);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Bishop bishop)
                {
                    if(bishop.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
                }
                if(finalPiece is Queen queen)
                {
                    if(queen.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
                }
            }

            // Checking for horizontal (queens and rooks):
            moves = new List<Move>();
            Movement.HorizontalMovement(moves, chessMatch, this, true);
            foreach(var move in moves)
            {
                Piece? finalPiece = move.FinalPosition.Piece;
                if(finalPiece is Rook rook)
                {
                    if(rook.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
                }
                if(finalPiece is Queen queen)
                {
                    if(queen.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
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
                    if(pawn.Color != Color)
                    {
                        if(possibleCheck != null) possibleCheck.Reverse();
                        return true;
                    }
                }
            }

            if(possibleCheck != null) possibleCheck.Reverse();
            return false;
        }

        public void VerifyMate(ChessMatch chessMatch)
        {
            Board board = chessMatch.Board;
            List<Move> moves = new List<Move>();
            foreach(var position in board.Positions)
            {
                if(position.Piece != null)
                {
                    if(position.Piece.Color == Color)
                    {
                        moves.AddRange(position.Piece.GetMoves(chessMatch));
                    }
                }
            }
            if(moves.Count == 0)
            {
                if(Checked) throw new MateException($"Check-mate!\n{(Color)((-1)*(int)Color)} wins!");
                throw new MateException("Stale-mate!\nIt's a draw!");
            }
        }
        
        public override string ToString()
        {
            return "K";
        }
    }
}