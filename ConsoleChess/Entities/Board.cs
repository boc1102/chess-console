using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Entities
{
    public class Board
    {
        public Position[,] Positions {get;}

        public Board()
        {
            Positions = new Position[8, 8];

            // Empty positions:
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Positions[i, j] = new Position(i, j);
                }
            }
            // Pawns:
            for(int j = 0; j < 8; j++)
            {
                new Pawn(Color.Black, Positions[1, j]);
                new Pawn(Color.White, Positions[6, j]);
            }
            // Rooks:
            new Rook(Color.Black, Positions[0, 0]);
            new Rook(Color.Black, Positions[0, 7]);
            new Rook(Color.White, Positions[7, 0]);
            new Rook(Color.White, Positions[7, 7]);
            // Knights:
            new Knight(Color.Black, Positions[0, 1]);
            new Knight(Color.Black, Positions[0, 6]);
            new Knight(Color.White, Positions[7, 1]);
            new Knight(Color.White, Positions[7, 6]);
            // Bishops:
            new Bishop(Color.Black, Positions[0, 2]);
            new Bishop(Color.Black, Positions[0, 5]);
            new Bishop(Color.White, Positions[7, 2]);
            new Bishop(Color.White, Positions[7, 5]);
            // Queens:
            new Queen(Color.Black, Positions[0, 3]);
            new Queen(Color.White, Positions[7, 3]);
            // Kings:
            new King(Color.Black, Positions[0, 4]);
            new King(Color.White, Positions[7, 4]);
        }
    
        public Position GetPosition(int line, int column)
        {
            return Positions[line, column];
        }
    }
}