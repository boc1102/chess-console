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
    }
}