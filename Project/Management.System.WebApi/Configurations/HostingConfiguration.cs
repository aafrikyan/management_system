using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Management.System.WebApi.Configurations;

public static class HostingConfiguration
{
    public static void Hosting(this WebApplicationBuilder builder)
    {
        //if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")))
        //{
        //    if (builder.Configuration.GetSection("Kestrel").Exists())
        //    {
        //        builder.WebHost.ConfigureKestrel((context, options) =>
        //        {
        //            options.Configure(context.Configuration.GetSection("Kestrel"));
        //        });
        //    }
        //}
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            builder.WebHost
                .UseIISIntegration()
                .UseIIS();
        }
        else
        {
            if (builder.Configuration.GetSection("Kestrel").Exists())
            {
                builder.WebHost.ConfigureKestrel((context, options) =>
                {
                    options.Configure(context.Configuration.GetSection("Kestrel"));
                });
            }
            builder.WebHost
                .UseKestrel(options => { options.ConfigureEndpointDefaults(end => end.Protocols = HttpProtocols.Http1AndHttp2); });
            builder.Services.AddSystemd();
        }
        builder.Services.AddControllers();
    }
}