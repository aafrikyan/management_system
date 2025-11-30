using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Management.System.Infrastructure.Constants;
using Management.System.Infrastructure.Handlers;

namespace Management.System.Infrastructure.Configurations;

public static class FinancialHttpClient
{
    public static void AddFinancialHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient(HttpClients.FinancialApi)
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new FinancialHttpMessageHandler((request, cancellationToken) =>
                {
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
                });
            });
    }
}
