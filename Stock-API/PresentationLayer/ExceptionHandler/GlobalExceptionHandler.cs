using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MySql.Data.MySqlClient;
using AutoMapper;

namespace PresentationLayer.ExceptionHandler;
public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);

        }
        catch(ValidationException exception)
        {
            _logger.LogError(exception.StackTrace);
            await HandleValidationExceptionAsync(context, exception);
        }
        catch(ArgumentNullException exception)
        {
            _logger.LogError(exception, "AutoMapper Cannot map objects");
            await HandleArgumentNullException(context, exception);
        }
        catch(MySqlException exception)
        {
            _logger.LogError(exception.StackTrace);
        }
        catch(AutoMapperMappingException exception)
        {
            _logger.LogError(exception, "AutoMapper Cannot map objects");
            await HandleAnonymousException(context, exception);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Internal Error !!!");
            await HandleAnonymousException(context, exception);
        }
    }

    public static Task HandleArgumentNullException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;
        var Response = new
        {
            Status="Error",
            StatusCode = context.Response.StatusCode,
            Message = "An argument is null",
            Details = exception.Message
        };
        return context.Response.WriteAsync(JsonSerializer.Serialize(Response));
    }

    private static Task HandleValidationExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;
        var Response = new
        {
            Status="Error",
            StatusCode = context.Response.StatusCode,
            Message = "Validation Failed",
            Details = e.Message
        };
        return context.Response.WriteAsync(JsonSerializer.Serialize(Response));
    }

    private static Task HandleAnonymousException(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        var Response = new
        {
            Status="Error",
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error",
            Details = "Something Went Wrong, Please try after some time!"
        };
        return context.Response.WriteAsync(JsonSerializer.Serialize(Response));
    }
}