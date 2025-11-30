using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Management.System.Shared.Repositories.Abstractions;

public interface IRepository<T>
{
    Task<T> CreateAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector);
    Task<T> UpdateAsync(T entity);
}