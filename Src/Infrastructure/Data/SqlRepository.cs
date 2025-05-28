using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Contracts.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public abstract class SqlRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : notnull
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> entities;

        public SqlRepository(DbContext dbContext)
        {
            context = dbContext;
            entities = dbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate
        )
        {
            return await entities.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            var entity = await entities.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync<TEntity>();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<TEntity>> SearchAsync(SearchData searchData)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
