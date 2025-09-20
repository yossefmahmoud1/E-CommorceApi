using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Producr;
using Microsoft.EntityFrameworkCore;
using Presention.Data;

namespace Persistence.Repositeryies
{
    public class GenricRepositery<TENtity, Tkey>(StoreDbContext _dbContext) : IGenricRepositery<TENtity, Tkey> where TENtity :BaseEntity<Tkey>
    {






        public async Task AddAsync(TENtity eNtity)
        {
        await    _dbContext.Set<TENtity>().AddAsync(eNtity);

        }

        public void  Delete(TENtity eNtity)
        {
             _dbContext.Set<TENtity>().Remove(eNtity);
        }

        public async Task<IEnumerable<TENtity>> GetAllAsync()
        {
        return    await _dbContext.Set<TENtity>().ToListAsync();
        }

        

        public async Task<TENtity> GetbyIDAsync(Tkey Id)
        {
          var result=  await _dbContext.Set<TENtity>().FindAsync(Id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Entity with ID {Id} not found.");
            }
            return result;
        }

       

        public void Update(TENtity eNtity)
        {
          _dbContext.Set<TENtity>().Update(eNtity);
        }











        public async Task<TENtity> GetbyIDAsync(ISpecification<TENtity, Tkey> Specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TENtity>()
                , Specifications).FirstOrDefaultAsync();


        }



        public async Task<IEnumerable<TENtity>> GetAllAsync(ISpecification<TENtity, Tkey> Specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TENtity>(), Specifications).ToListAsync();
        }

        public Task<int> CountAsync(ISpecification<TENtity, Tkey> specifications)
        {

            return SpecificationEvaluator.CreateQuery(_dbContext.Set<TENtity>(), specifications).CountAsync();
        }

    }
}
