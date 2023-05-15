using ConsoleChess.Game;
using ConsoleChess.Entities;

ChessMatch chessMatch = new ChessMatch();
Board board = chessMatch.Board;

while(chessMatch.Running)
{
    try
    {
        ConsoleHandler.PrintBoard(chessMatch.Board);
        Console.Write("Select piece: ");
        int[] index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
        Position startPosition = chessMatch.GetStartPosition(index[0], index[1]);

        List<Move> possibleMoves = startPosition.Piece!.GetMoves(board);
        board.SelectPositions(possibleMoves);
        chessMatch.Update();

        Console.Write("Select position: ");
        index = ConsoleHandler.HandleInput(Console.ReadLine() ?? "");
        Position finalPosition = board.GetPosition(index[0], index[1]);
        board.UnselectPositions();
        chessMatch.Update();

        Move move = new Move(startPosition, finalPosition);
        chessMatch.Board.MovePiece(move, possibleMoves);

        Console.WriteLine(move);
    }
    catch(ApplicationException e)
    {
        Console.WriteLine(e.Message);
    }
}

