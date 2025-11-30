using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Management.System.Shared.Repositories.Abstractions;
using Management.System.Infrastructure.Persistence;

namespace Management.System.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly WorkflowContext context;

    public Repository(WorkflowContext workflowContext)
    {
        context = workflowContext;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>()
            .AsQueryable()
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector)
    {
        return await context.Set<T>()
            .AsQueryable()
            .Select(selector)
            .ToListAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbSet<T> set = context.Set<T>();
        set.Attach(entity);
        EntityEntry<T> entry = context.Entry(entity);
        HashSet<string> keyNames = entry.Metadata
            .FindPrimaryKey()
            .Properties
            .Select(p => p.Name)
            .ToHashSet() ?? new HashSet<string>();
        IProperty version = entry.Metadata
            .GetProperties()
            .FirstOrDefault(p => p.IsConcurrencyToken);
        foreach (PropertyEntry property in entry.Properties)
        {
            string name = property.Metadata.Name;
            if (keyNames.Contains(name))
            {
                continue;
            }
            if (version != null && name == version.Name)
            {
                continue;
            }
            property.IsModified = true;
        }
        PropertyEntry versionProperty = entry.Property(version.Name);
        versionProperty.CurrentValue = Guid.NewGuid();
        versionProperty.IsModified = true;
        await context.SaveChangesAsync();
        return entity;
    }

}
