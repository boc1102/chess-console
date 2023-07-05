using ConsoleChess.Game;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities.Pieces
{
    public class Pawn : Piece
    {
        public int? LongStartTurn {get; internal set;}
        public Pawn(Color color, Position currentPosition) : base(color, currentPosition)
        {
            LongStartTurn = null;
        }

        public override string ToString()
        {
            return "P";
        }

        public override List<Move> GetMoves(ChessMatch chessMatch)
        {
            King king = chessMatch.Kings[chessMatch.TurnColor];
            Board board = chessMatch.Board;

            int currentLine = CurrentPosition.Line;
            int currentCollumn = CurrentPosition.Column;

            Position[,] positions = board.Positions;
            List<Move> possibleMoves = new List<Move>();

            if(LongStartTurn == null)
            {
                int line = currentLine + 1 * (int)Color;
                Position midPosition = positions[line, currentCollumn];
                line = CurrentPosition.Line + 2 * (int)Color;
                Position finalPosition = positions[line, currentCollumn];

                if(midPosition.Piece == null && finalPosition.Piece == null)
                {
                    Move move = new Move(CurrentPosition, finalPosition);
                    if(!king.VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
            }

            try
            {
                Position frontPosition = positions[currentLine + 1 * (int)Color, currentCollumn];
                if(frontPosition.Piece == null)
                {
                    Move move = new Move(CurrentPosition, frontPosition);
                    if(!king.VerifyCheck(chessMatch, move))
                        possibleMoves.Add(move);
                }
                    
            }
            catch(IndexOutOfRangeException){}
            
            try
            {
                Position takeRight = positions[currentLine + 1 * (int)Color, currentCollumn + 1];
                if(takeRight.Piece != null)
                    if(takeRight.Piece.Color != Color)
                    {
                        Move move = new Move(CurrentPosition, takeRight);
                        if(!king.VerifyCheck(chessMatch, move))
                            possibleMoves.Add(move);
                    }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position takeLeft = positions[currentLine + 1 * (int)Color, currentCollumn - 1];
                if(takeLeft.Piece != null)
                    if(takeLeft.Piece.Color != Color)
                    {
                        Move move = new Move(CurrentPosition, takeLeft);
                        if(!king.VerifyCheck(chessMatch, move))
                            possibleMoves.Add(move);
                    }
            }
            catch(IndexOutOfRangeException){}

            try
            {
                Position enPassantRight = positions[currentLine, currentCollumn + 1];
                if(enPassantRight.Piece is Pawn rightPawn)
                    if(rightPawn.Color != Color && rightPawn.LongStartTurn == chessMatch.Turn - 1)
                    {
                        Position position = positions[currentLine + 1 * (int)Color, currentCollumn + 1];
                        Move move = new Move(CurrentPosition, position, enPassantRight);
                        if(!king.VerifyCheck(chessMatch, move))
                            possibleMoves.Add(move);
                    }
            }
            catch(IndexOutOfRangeException){}
            
            try
            {
                Position enPassantLeft = positions[currentLine, currentCollumn - 1];
                if(enPassantLeft.Piece is Pawn leftPawn)
                    if(leftPawn.Color != Color && leftPawn.LongStartTurn == chessMatch.Turn - 1)
                    {
                        Position position = positions[currentLine + 1 * (int)Color, currentCollumn - 1];
                        Move move = new Move(CurrentPosition, position, enPassantLeft);
                        if(!king.VerifyCheck(chessMatch, move))
                            possibleMoves.Add(move);
                    }
            }
            catch(IndexOutOfRangeException){}
            
            return possibleMoves;
        }
    }
}