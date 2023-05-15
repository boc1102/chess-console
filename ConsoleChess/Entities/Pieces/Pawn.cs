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
                    possibleMoves.Add(new Move(CurrentPosition, finalPosition));
            }

            Position frontPosition = positions[currentLine + 1 * (int)Color, currentCollumn];
            if(frontPosition.Piece == null)
                possibleMoves.Add(new Move(CurrentPosition, frontPosition));

            Position takeRight = positions[currentLine + 1 * (int)Color, currentCollumn + 1];
            if(takeRight.Piece != null)
                if(takeRight.Piece.Color != Color) possibleMoves.Add(new Move(CurrentPosition, takeRight));

            Position takeLeft = positions[currentLine + 1 * (int)Color, currentCollumn - 1];
            if(takeLeft.Piece != null)
                if(takeLeft.Piece.Color != Color) possibleMoves.Add(new Move(CurrentPosition, takeLeft));

            Position enPassantRight = positions[currentLine, currentCollumn + 1];
            if(enPassantRight.Piece is Pawn rightPawn)
                if(rightPawn.Color != Color && rightPawn.LongStartTurn == chessMatch.Turn - 1)
                {
                    Position position = positions[currentLine + 1 * (int)Color, currentCollumn + 1];
                    possibleMoves.Add(new Move(CurrentPosition, position, enPassantRight));
                }

            Position enPassantLeft = positions[currentLine, currentCollumn - 1];
            if(enPassantLeft.Piece is Pawn leftPawn)
                if(leftPawn.Color != Color && leftPawn.LongStartTurn == chessMatch.Turn - 1)
                {
                    Position position = positions[currentLine + 1 * (int)Color, currentCollumn - 1];
                    possibleMoves.Add(new Move(CurrentPosition, position, enPassantLeft));
                }
            
            return possibleMoves;
        }
    }
}