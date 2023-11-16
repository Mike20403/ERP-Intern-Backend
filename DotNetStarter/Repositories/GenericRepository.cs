using Microsoft.EntityFrameworkCore;
using DotNetStarter.Entities;
using DotNetStarter.Common.Models;
using System.Linq.Expressions;
using DotNetStarter.Extensions;
using Microsoft.EntityFrameworkCore.Query;

namespace DotNetStarter.Repositories
{
    public class GenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        internal TDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(TDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ListAsync(
            string? orderBy = null,
            string? includeProperties = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = Filter(orderBy, includeProperties, pageNumber, pageSize, filter);
            return await query.ToListAsync();
        }

        public virtual async Task<PagedList<TEntity>> GetPagedListAsync(
            string? orderBy = null,
            string? includeProperties = null,
            int pageNumber = 0,
            int pageSize = 25,
            params Expression<Func<TEntity, bool>>[] filter)
        {
            var items = await Filter(orderBy, includeProperties, pageNumber, pageSize, filter).ToListAsync();
            var count = await CountAsync(filter);

            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }

        public virtual async Task<int> CountAsync(params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = Filter(filter: filter);
            return await query.CountAsync();
        }

        public virtual async Task<bool> AnyAsync(params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = Filter(filter: filter);
            return await query.AnyAsync();
        }

        public virtual async Task<TEntity?> FindAsync(
            string? includeProperties = null,
            params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = Filter(includeProperties: includeProperties, filter: filter);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await dbSet.AddAsync(entity)).Entity;
        }

        public virtual Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public virtual Task UpdatesAsync(params TEntity[] entityToUpdates)
        {
            dbSet.AttachRange(entityToUpdates);
            dbSet.UpdateRange(entityToUpdates);

            return Task.CompletedTask;
        }

        public virtual async Task<int> BulkUpdateAsync
        (
            Expression<Func<TEntity, bool>> condition, 
            Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression
        )
        {
            return await context.Set<TEntity>().Where(condition).ExecuteUpdateAsync(expression);
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity? entityToDelete = await dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                await DeleteAsync(entityToDelete);
            }
        }

        public virtual Task DeleteAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            return Task.CompletedTask;
        }
        public virtual Task DeletesAsync(params TEntity[] entityToDeletes)
        {
            dbSet.AttachRange(entityToDeletes);
            dbSet.RemoveRange(entityToDeletes);

            return Task.CompletedTask;
        }

        private IQueryable<TEntity> Filter(
            string? orderBy = null,
            string? includeProperties = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var item in filter)
            {
                query = query.Where(item);
            }

            query = query.OrderBy(orderBy);

            query = query.IncludeProperties(includeProperties);

            if (pageNumber != null && pageSize != null)
            {
                query = query.Skip(pageNumber!.Value * pageSize!.Value).Take(pageSize!.Value);
            }

            return query;
        }
    }
}
