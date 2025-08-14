
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // You can add logic here before the next middleware
        await _next(context); // Pass control to the next middleware
        // You can add logic here after the next middleware has run
    }
}