using ConsoleChess.Entities.Pieces;
namespace ConsoleChess.Entities
{
    public class Position
    {
        public Piece? Piece {get; internal set;}
        public int Line {get;}
        public int Column {get;}

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }
}