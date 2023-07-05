using ConsoleChess.Entities;
using ConsoleChess.Entities.Pieces;
using ConsoleChess.Entities.Enums;

namespace ConsoleChess.Game
{
    public static class ConsoleHandler
    {
        public static void PrintBoard(Board board)
        {   
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            for(int i = 0; i < 8; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{8 - i} ");
                for(int j = 0; j < 8; j++)
                {
                    Position position = board.Positions[i, j];
                    if(position.Selected) Console.BackgroundColor = ConsoleColor.DarkYellow;
                    else if(position.Piece is King {Checked: true})
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        if((i + j) % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkGray;
                        else Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    
                    Piece? piece = position.Piece;
                    if(piece != null)
                    {
                        if(piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.Black;
                        else Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write($" {(piece != null ? piece : " ")} ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" {8 - i}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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