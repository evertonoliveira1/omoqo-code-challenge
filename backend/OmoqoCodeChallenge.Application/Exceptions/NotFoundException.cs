namespace OmoqoCodeChallenge.Application.Exceptions
{
    public class NotFoundItemException : Exception
    {
        public NotFoundItemException(string? message) : base(message)
        {
        }
    }
}
