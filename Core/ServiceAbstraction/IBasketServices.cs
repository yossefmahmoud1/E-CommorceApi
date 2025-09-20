using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BasketDtos;

namespace ServiceAbstraction
{
    public interface IBasketServices
    {

        Task<BasketDto> GetBasketDto(String Key);
        Task<BasketDto> CreateOrUpdateBasket(BasketDto basket );
        Task<bool> DeleteBasketAsync(String Key);



    }
}
