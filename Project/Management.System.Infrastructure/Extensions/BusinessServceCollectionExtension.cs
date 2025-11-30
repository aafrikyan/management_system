using System;
using Microsoft.Extensions.DependencyInjection;
using Management.System.Business.Services;
using Management.System.Business.Services.Abstractions;

namespace Management.System.Infrastructure.Extensions;

public static class BusinessServceCollectionExtension
{
    public static void AddBusimessServices(this IServiceCollection services)
    {
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IWorkflowService, WorkflowService>();
    }
}