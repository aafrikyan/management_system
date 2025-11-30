using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Management.System.Shared.Persistence.Abstractions;

public interface IWorkflowContext
{
    ChangeTracker ChangeTracker { get; }
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
    void AttachRange(IEnumerable<object> entities);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
    Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
}