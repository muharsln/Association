using Association.Core.Exceptions.Common;
using Newtonsoft.Json;

namespace Association.WebAPI.Middleware;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception)
        {
            await HandleExceptionAsync(context, new ApiException("SERVER_ERROR", "An unexpected error occurred.", null));
        }
    }

    private Task HandleExceptionAsync(HttpContext context, ApiException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var response = new
        {
            errorCode = exception.ErrorCode,
            message = exception.Message,
            solution = exception.Solution
        };

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
