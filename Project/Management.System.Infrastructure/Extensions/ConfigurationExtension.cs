using System;
using Microsoft.Extensions.Configuration;

namespace Management.System.Infrastructure.Extensions;

public static class ConfigurationExtension
{
    public static IConfiguration Config(this ConfigurationBuilder builder)
    {
        builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (!string.IsNullOrEmpty(environment))
        {
            builder.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: false);
            return builder.Build();
        }
        builder.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false);
        return builder.Build();
    }
}