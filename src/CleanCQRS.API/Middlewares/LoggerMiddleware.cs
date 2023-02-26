namespace CleanCQRS.API.Middlewares;

public class LoggerMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    public LoggerMiddleware(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        finally
        {
            _logger.LogInformation(
                $"Request {context.Request.Method} {context.Request.Path.Value} => {context.Response.StatusCode}");
        }
    }
}