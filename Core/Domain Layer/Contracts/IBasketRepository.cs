using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Basket;

namespace Domain_Layer.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetCustomerBasketasync(string Id);
        Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TimeTolive = null);
        Task<bool> DeleteBasketasync(string id);
    }
}
