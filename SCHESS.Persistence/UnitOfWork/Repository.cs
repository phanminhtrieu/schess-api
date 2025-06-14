using Microsoft.EntityFrameworkCore;
using SCHESS.Domain.Entity;
using SCHESS.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Persistence.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<int>
    {
        protected DbContext _dbContext { get; }
        protected DbSet<TEntity> _entities { get; }

        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _entities = _dbContext.Set<TEntity>();
        }

        public Repository(AppDbContext dbContext) : this((DbContext)dbContext)  { }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _entities.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _entities.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = _entities.Find(id);

            if (entity is not null)
            {
                _entities.Remove(entity);
            }
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

       
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            if (filter == null)
            {
                return await _entities.CountAsync(cancellationToken);
            }

            return await _entities.CountAsync(filter, cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            if (filter == null)
            {
                return await _entities.AnyAsync(cancellationToken);
            }

            return await _entities.AnyAsync(filter, cancellationToken);
        }
    }
}
