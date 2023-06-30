using System.Collections;
using ConsoleChess.Entities;
using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Game
{
    public class ChessMatch
    {
        public Board Board {get;}
        public Dictionary<Color, King> Kings {get;}
        public Color TurnColor {get; private set;}
        public int Turn {get; private set;}
        public bool Running {get;}

        public ChessMatch()
        {
            Board = new Board();
            Kings = new Dictionary<Color, King>
            {
                {Color.Black, (King)Board.Positions[0, 4].Piece!},
                {Color.White, (King)Board.Positions[7, 4].Piece!}
            };
            Turn = 0;
            TurnColor = Color.White;
            Running = true;
        }

        public Position GetStartPosition(int line, int column)
        {
            Position position = Board.GetPosition(line, column);
            int turnColor = Turn % 2 == 0 ? -1 : 1;

            if(position.Piece == null) throw new ApplicationException("This shits null!!!");
            else
            {
                if((int)position.Piece.Color == turnColor)
                    return position;
                else throw new ApplicationException("It's not your fucking turn!!!");
            }
        }

        public void MovePiece(Move move, List<Move> possibleMoves)
        {
            Move? foundMove = null;

            foreach(var x in possibleMoves)
            {
                if(x.StartPosition == move.StartPosition && x.FinalPosition == move.FinalPosition)
                    foundMove = x;
            }

            if(foundMove != null)
            {
                if(foundMove.Execute())
                {
                    Piece? finalPiece = move.FinalPosition.Piece;
                    if(Kings[TurnColor].VerifyCheck(Board))
                    {
                        move.Reverse();
                        throw new ApplicationException("Your King can't be in Check at the end of your turn.");
                    }
                    if(finalPiece is Pawn pawn)
                        if(pawn.LongStartTurn == null) pawn.LongStartTurn = Turn;
                    if(finalPiece is King {Moved: false})
                    {
                        King king = (finalPiece as King)!;
                        king.Moved = true;
                    } 
                    if(finalPiece is Rook {Moved: false})
                    {
                        Rook rook = (finalPiece as Rook)!;
                        rook.Moved = true;
                    }

                    Turn++;
                    TurnColor = (Color)(-(int)TurnColor);
                }
            }
        }

        public void Update(string error = "")
        {
            Console.Clear();
            ConsoleHandler.PrintBoard(Board);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
            Color color = (Color)(Turn % 2 == 0 ? -1 : 1);
            if(Kings[TurnColor].VerifyCheck(Board)) Console.WriteLine("Check!");
            Console.WriteLine($"Turn: {color}");
        }
    }
}