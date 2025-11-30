using System;
using Microsoft.Extensions.DependencyInjection;
using Management.System.Shared.Repositories.Abstractions;
using Management.System.Infrastructure.Repositories;

namespace Management.System.Infrastructure.Extensions;

public static class RepositoryServiceCollectionExtension
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
