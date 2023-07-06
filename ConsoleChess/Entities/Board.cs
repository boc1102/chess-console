using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities
{
    public class Board
    {
        public Position[,] Positions {get;}

        public Board(string format = "Entities\\default.txt")
        {
            Positions = new Position[8, 8];

            StreamReader sr = new StreamReader(format);

            for(int i = 0; i < 8; i++)
            {
                string line = sr.ReadLine() ?? "";
                string[] pieces = line.Trim().Split(' ');

                for(int j = 0; j < 8; j++)
                {
                    Positions[i, j] = new Position(i, j);
                    Position position = Positions[i, j];

                    char piece = char.Parse(pieces[j]);
                    Color color = char.IsLower(piece) ? Color.White : Color.Black;
                    piece = char.ToUpper(piece);

                    switch(piece)
                    {
                        case 'R':
                            new Rook(color, position);
                            break;
                        case 'N':
                            new Knight(color, position);
                            break;
                        case 'B':
                            new Bishop(color, position);
                            break;
                        case 'Q':
                            new Queen(color, position);
                            break;
                        case 'K':
                            new King(color, position);
                            break;
                        case 'P':
                            new Pawn(color, position);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    
        public Position GetPosition(int line, int column)
        {
            return Positions[line, column];
        }
    
        public void SelectPositions(Position startPosition, List<Move> possibleMoves)
        {
            startPosition.Selected = true;
            foreach(var move in possibleMoves)
            {
                move.FinalPosition.Selected = true;
            }
        }

        public void UnselectPositions()
        {
            foreach(var position in Positions)
            {
                position.Selected = false;
            }
        }
    }
}