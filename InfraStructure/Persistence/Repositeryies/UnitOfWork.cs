using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Producr;
using Presention.Data;

namespace Persistence.Repositeryies
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {



        private readonly Dictionary<string, object> _repositeries = [];
        public IGenricRepositery<TEntity, Tkey> GetRepositery<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {

            var TypeName=typeof(TEntity).Name;
            //if(_repositeries.ContainsKey(TypeName))
            //    return (IGenricRepositery<TEntity , Tkey>) _repositeries[TypeName];

                if(_repositeries.TryGetValue(TypeName,out object? value))
                return (IGenricRepositery<TEntity , Tkey>) value;


            else
            {
                var Repo=new GenricRepositery<TEntity, Tkey>(_dbContext);
                _repositeries[TypeName] = Repo;
                return Repo;
            }



        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    
    }
}
