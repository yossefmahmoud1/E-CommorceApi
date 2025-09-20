using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Contracts
{
    public interface IGenricRepositery<TENtity , Tkey> where TENtity:BaseEntity<Tkey>
    {

        Task<IEnumerable<TENtity>> GetAllAsync();
        Task<IEnumerable<TENtity>> GetAllAsync(ISpecification<TENtity , Tkey> Specifications);
        Task<TENtity> GetbyIDAsync(Tkey Id);

        Task<TENtity> GetbyIDAsync(ISpecification<TENtity, Tkey> Specifications);
        Task AddAsync(TENtity eNtity);
        void Update(TENtity eNtity);
        void Delete(TENtity eNtity);

        Task<int> CountAsync(ISpecification<TENtity , Tkey> specifications) ;

    }
}
