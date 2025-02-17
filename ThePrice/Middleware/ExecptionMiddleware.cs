using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ThePrice.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        switch (exception)
        {
            case ValidationException validationException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { errors = validationException.Message }));

            case UnauthorizedAccessException unauthorizedAccessException:
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message=unauthorizedAccessException.Message }));

            case FormatException formatException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = formatException.Message }));

            case KeyNotFoundException _:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = exception.Message }));

            case InvalidOperationException _:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = exception.Message }));

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Internal Server Error." }));
        }
    }
}
