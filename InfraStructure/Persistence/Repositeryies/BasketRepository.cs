using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Basket;
using StackExchange.Redis;

namespace Persistence.Repositeryies
{
    public class BasketRepository(IConnectionMultiplexer ConnectionMultiplexer)  : IBasketRepository
    {

        private readonly IDatabase _database = ConnectionMultiplexer.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TimeTolive = null)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
            var JsonBasket = JsonSerializer.Serialize(basket, options);
            var IsCreatedOrUpdated = await _database.StringSetAsync(basket.Id, JsonBasket, TimeTolive ?? TimeSpan.FromDays(30));


            if (IsCreatedOrUpdated)
            {

                return await GetCustomerBasketasync(basket.Id);
            }
            else
            {
                return null;
            }



        }

        public async Task<bool> DeleteBasketasync(string id)
        {

      return   await   _database.KeyDeleteAsync(id);



}

        public async Task<CustomerBasket?> GetCustomerBasketasync(string Key)
        {
            var Basket =  await _database.StringGetAsync(Key);

            if (Basket.IsNullOrEmpty) {

                return null;
            
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!, options);
            }
                
                
                }

    }
}
