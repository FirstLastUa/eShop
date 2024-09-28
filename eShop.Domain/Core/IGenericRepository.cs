using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Core
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
