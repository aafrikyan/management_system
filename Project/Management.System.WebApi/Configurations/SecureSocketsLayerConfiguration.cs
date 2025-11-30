using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Management.System.WebApi.Configurations;

public static class SecureSocketsLayerConfiguration
{
    public static void AddSecureSocketsLayer(this WebApplication application)
    {
        if (application.Configuration.GetValue<bool>("Application:Ssl:Active"))
        {
            if (application.Configuration.GetValue<bool>("Application:Ssl:Hsts"))
            {
                application.UseHsts();
            }
            if (application.Configuration.GetValue<bool>("Application:Ssl:Redirection"))
            {
                application.UseHttpsRedirection();
            }
        }
    }
}