using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Management.System.WebApi.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        next = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return;
        }
    }
}