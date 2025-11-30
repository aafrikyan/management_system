using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Management.System.Infrastructure.Persistence;

namespace Management.System.Infrastructure.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<WorkflowContext>(options =>
            options.UseSqlServer(config["ConnectionStrings:DefaultConnection"], b => b.CommandTimeout(15000))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped);
    }
}