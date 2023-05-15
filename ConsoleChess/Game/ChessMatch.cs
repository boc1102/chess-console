using ConsoleChess.Entities;
using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Game
{
    public class ChessMatch
    {
        public Board Board {get;}
        public int Turn {get; private set;}
        public bool Running {get;}

        public ChessMatch()
        {
            Board = new Board();
            Turn = 0;
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
                    if(move.FinalPosition.Piece is Pawn pawn)
                        if(pawn.LongStartTurn == null) pawn.LongStartTurn = Turn;
                    
                    Turn++;
                }
            }
        }

        public void Update()
        {
            ConsoleHandler.PrintBoard(Board);
            Color color = (Color)(Turn % 2 == 0 ? -1 : 1);
            Console.WriteLine($"Turn: {color}");
        }
    }
}