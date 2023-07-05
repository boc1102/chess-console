namespace ConsoleChess.Exceptions
{
    public class MateException : ApplicationException
    {
        public MateException(string message) : base(message){}
    }
}