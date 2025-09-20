using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Contracts;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Basket;
using ServiceAbstraction;
using Shared.BasketDtos;

namespace Service
{
    public class BasketServices(IBasketRepository basketRepository ,IMapper mapper) : IBasketServices
    {
        public async Task<BasketDto> CreateOrUpdateBasket(BasketDto basket)
        {
            if (basket is null)
                throw new BasketNotFoundEx("null");

            if (string.IsNullOrEmpty(basket.Id))
                throw new BasketNotFoundEx("Basket ID is required");

            // Map DTO to domain model
            var customerBasket = mapper.Map<BasketDto, CustomerBasket>(basket);
            
            // Create or update basket in Redis
            var createOrUpdateResult = await basketRepository.CreateOrUpdateAsync(customerBasket);
            if (createOrUpdateResult is null)
                throw new BasketNotFoundEx(basket.Id);

            // Map result back to DTO and return
            return mapper.Map<CustomerBasket, BasketDto>(createOrUpdateResult);

        }

        public async Task<bool> DeleteBasketAsync(string Key)
        {
            var result = await basketRepository.DeleteBasketasync(Key);
            if (!result)
                throw new BasketNotFoundEx(Key);
                
            return true;
        }

        public async Task<BasketDto> GetBasketDto(string Id)
        {
            var Basket = await basketRepository.GetCustomerBasketasync(Id);
            if (Basket == null) {
                throw new BasketNotFoundEx(Id);
            }
            
            return mapper.Map<CustomerBasket, BasketDto>(Basket);


                }
    }
}
