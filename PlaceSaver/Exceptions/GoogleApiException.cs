namespace PlaceSaver.Exceptions;

public class GoogleApiException : Exception
{
    public GoogleApiException(string message, Exception exception)
        : base(message)
    {
    }

    public GoogleApiException(string message) : base(message)
    {
    }
}