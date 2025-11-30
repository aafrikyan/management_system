using System;
using Microsoft.AspNetCore.Builder;

namespace Management.System.WebApi.Configurations;

public static class RouteConfiguration
{
    public static void AddRoute(this WebApplication application)
    {
        application.MapControllers();
    }
}