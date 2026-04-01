using Core.Application.Wrappers;
using Core.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Presentacion.WebAP.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            await Handle(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (DbUpdateConcurrencyException)
        {
            await Handle(context, HttpStatusCode.Conflict, "Concurrency conflict detected.");
        }
        catch (Exception ex)
        {
            await Handle(context, HttpStatusCode.InternalServerError, ex.ToString());
        }
    }

    private static async Task Handle(HttpContext context, HttpStatusCode status, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        var response = Response.Fail(message);

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}