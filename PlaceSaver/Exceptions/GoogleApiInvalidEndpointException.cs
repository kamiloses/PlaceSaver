namespace PlaceSaver.Exceptions;

public class GoogleApiInvalidEndpointException : Exception
{
    public GoogleApiInvalidEndpointException(string? message) : base(message)
    {
    }
}