using Management.System.Domain;
using Management.System.Infrastructure.Persistence.Configurations;
using Management.System.Infrastructure.Persistence.Data;
using Management.System.Shared.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;

namespace Management.System.Infrastructure.Persistence;

public class WorkflowContext : DbContext, IWorkflowContext
{
    public WorkflowContext(DbContextOptions<WorkflowContext> options) : base(options)
    {
    }

    public virtual DbSet<Role> Role { get; private set; }
    public IQueryable<Role> Roles => Role;

    public virtual DbSet<User> User { get; private set; }
    public IQueryable<User> Users => User;

    public virtual DbSet<Workflow> Workflow { get; private set; }
    public IQueryable<Workflow> Workflows => Workflow;

    public virtual DbSet<Step> Step { get; private set; }
    public IQueryable<Step> Steps => Step;

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Database.BeginTransactionAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(WorkflowContext).Assembly);

        RoleData.Seed(builder);
        UserData.Seed(builder);
    }
}