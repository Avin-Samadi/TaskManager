using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Contracts.Data;

namespace Domain.Contracts
{
    public interface IRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : notnull
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> SearchAsync(SearchData searchData);
    }
}
