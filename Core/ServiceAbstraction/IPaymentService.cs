using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BasketDtos;

namespace ServiceAbstraction
{
    public interface IPaymentService
    {

        Task<BasketDto> CreateOrUpdatePayment(string BasketId);

         




    }
}
