using ConsoleChess.Exceptions;
using ConsoleChess.Game;
using ConsoleChess.Entities;
using ConsoleChess.Entities.Pieces;

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
        board.SelectPositions(startPosition, possibleMoves);
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
    catch(PromotionException e)
    {
        bool promoted = false;
        
        while(!promoted)
        {
            Console.Clear();
            ConsoleHandler.PrintBoard(board);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Message);
            Console.WriteLine("Select piece ('Q', 'N', 'B', 'R'):");
            
            string input = Console.ReadLine() ?? "";
            switch(input.ToUpper())
            {
                case "Q": 
                    new Queen(e.Piece.Color, e.Piece.CurrentPosition);
                    promoted = true;
                    break;
                case "N": 
                    new Knight(e.Piece.Color, e.Piece.CurrentPosition);
                    promoted = true;
                    break;
                case "B": 
                    new Bishop(e.Piece.Color, e.Piece.CurrentPosition);
                    promoted = true;
                    break;
                case "R": 
                    new Rook(e.Piece.Color, e.Piece.CurrentPosition);
                    promoted = true;
                    break;
            }
        }

        Console.ResetColor();
        chessMatch.Update();
    }
    catch(FormatException)
    {
        chessMatch.Update("Invalid entry!");
    }
    catch(IndexOutOfRangeException)
    {
        chessMatch.Update("Invalid entry!");
    }
    catch(ApplicationException e)
    {
        chessMatch.Update(e.Message);
    }
}

