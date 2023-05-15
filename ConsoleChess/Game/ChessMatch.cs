using ConsoleChess.Entities;

namespace ConsoleChess.Game
{
    public class ChessMatch
    {
        public Board Board {get;}
        private int Turn {get;}
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

        public void Update()
        {
            Console.Clear();
            ConsoleHandler.PrintBoard(Board);
        }
    }
}