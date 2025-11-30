using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Management.System.Infrastructure.Extensions;
using Management.System.Infrastructure.Configurations;
using Management.System.WebApi.Configurations;
using Management.System.WebApi.Middlewares;

namespace Management.System.WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        #region Environment

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Configuration.Sources.Clear();
        builder.Configuration.AddConfiguration(new ConfigurationBuilder().Config());
        builder.Hosting();

        #endregion

        #region Configure Services

        builder.Services.AddDatabaseContext(builder.Configuration);
        builder.Services.AddRepositoryServices();
        builder.Services.AddBusimessServices();
        builder.Services.AddFinancialHttpClient();
        builder.AddControllers();
        builder.AddVersioning();
        builder.Swagger();

        #endregion

        WebApplication application = builder.Build();

        #region Environment

        application.UseMiddleware<ExceptionMiddleware>();
        application.AddSecureSocketsLayer();
        application.UseRouting();
        application.UseAuthentication();
        application.UseAuthorization();
        application.Swagger();

        application.AddRoute();

        #endregion

        await application.RunAsync();
    }
}