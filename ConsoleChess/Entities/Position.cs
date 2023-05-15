using ConsoleChess.Entities.Pieces;
namespace ConsoleChess.Entities
{
    public class Position
    {
        public Piece? Piece {get; internal set;}
        public int Line {get;}
        public int Column {get;}
        public bool Selected {get; internal set;}

        public Position(int line, int column)
        {
            Selected = false;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            char column = (char)(Column + 97);
            int line = 8 - Line;
            return $"{Piece}({column}{line})";
        }
    }
}