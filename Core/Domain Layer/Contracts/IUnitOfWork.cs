using System;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Contracts
{
    public interface IUnitOfWork
    {
        IGenricRepositery<T, TId> GetRepositery<T, TId>() where T : BaseEntity<TId>;
        Task<int> SaveChangesAsync();
    }
}
