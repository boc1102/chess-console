using ConsoleChess.Game;
using ConsoleChess.Entities;

ChessMatch chessMatch = new ChessMatch();

ConsoleHandler.PrintBoard(chessMatch.Board);

while(chessMatch.Running)
{
    Console.Write("Select piece: ");
    int[] index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
    Position startPosition = chessMatch.Board.GetPosition(index[0], index[1]);

    Console.Write("Select position: ");
    index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
    Position finalPosition = chessMatch.Board.GetPosition(index[0], index[1]);

    Console.WriteLine(startPosition.Piece);
    Console.WriteLine(finalPosition.Piece);
}

