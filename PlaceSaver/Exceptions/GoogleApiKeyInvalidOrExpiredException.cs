namespace PlaceSaver.Exceptions;

public class GoogleApiKeyInvalidOrExpiredException : Exception
{
    public GoogleApiKeyInvalidOrExpiredException(string? message) : base(message)
    {
    }
}