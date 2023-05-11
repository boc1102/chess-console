using ConsoleChess.Entities;
using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Game
{
    public static class ConsoleHandler
    {
        public static void PrintBoard(Board board)
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            for(int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{8 - i} ");
                for(int j = 0; j < 8; j++)
                {
                    Piece? piece = board.Positions[i, j].Piece;
                    if(piece != null)
                    {
                        if(piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.DarkYellow;
                        else Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($" {(piece != null ? piece : " ")} ");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {8 - i}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   a  b  c  d  e  f  g  h ");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int[] HandleInput(string input)
        {
            input = input.Trim();

            int column = (int)input[0] - 97;
            int line = 8 - int.Parse(input[1].ToString());

            int[] indexes = {line, column};

            return indexes;
        }
    }
}