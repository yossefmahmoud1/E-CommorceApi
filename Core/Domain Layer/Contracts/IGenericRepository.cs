using System.Linq.Expressions;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Contracts
{
    public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task<TEntity?> GetbyIDAsync(TId id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}