namespace PlaceSaver.Exceptions;

public class GoogleApiFetchingException : Exception
{
    public GoogleApiFetchingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}