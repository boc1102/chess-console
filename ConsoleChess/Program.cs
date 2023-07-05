using ConsoleChess.Exceptions;
using ConsoleChess.Game;
using ConsoleChess.Entities;

ChessMatch chessMatch = new ChessMatch();
Board board = chessMatch.Board;
chessMatch.Update();

while(chessMatch.Running)
{
    try
    {
        Console.Write("Select piece: ");
        int[] index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
        Position startPosition = chessMatch.GetStartPosition(index[0], index[1]);
        chessMatch.Update();

        List<Move> possibleMoves = startPosition.Piece!.GetMoves(chessMatch);
        board.SelectPositions(possibleMoves);
        chessMatch.Update();

        Console.Write("Select position: ");
        index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
        Position finalPosition = board.GetPosition(index[0], index[1]);
        board.UnselectPositions();
        chessMatch.Update();

        Move move = new Move(startPosition, finalPosition);
        chessMatch.MovePiece(move, possibleMoves);
        chessMatch.Update();
    }
    catch(MateException e)
    {
        Console.Clear();
        ConsoleHandler.PrintBoard(board);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        chessMatch.Running = false;
    }
    catch(ApplicationException e)
    {
        chessMatch.Update(e.Message);
    }
}

