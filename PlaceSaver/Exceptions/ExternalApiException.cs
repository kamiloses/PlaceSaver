namespace PlaceSaver.Exceptions;

public class ExternalApiException : Exception
{
    public ExternalApiException(string message)
        : base(message)
    {
    }
}