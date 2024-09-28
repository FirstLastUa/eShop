using eShop.Domain.Core;
using eShop.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Repositories
{
    internal abstract class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly ApplicationDbContext DbContext = context;

        public virtual Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return DbContext.Set<TEntity>()
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public virtual void Add(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            DbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}
