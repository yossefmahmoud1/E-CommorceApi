using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.BasketDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController (IServiceManager serviceManager) : ControllerBase
    {
        [Authorize]
        [HttpPost("{BasketId}")]
        public async Task <ActionResult<BasketDto>> CreateOrUpdatePaymentIntent(string BasketId)
        {
            var Basket = await serviceManager.PaymentService.CreateOrUpdatePayment(BasketId);
            return Ok (Basket);


        }


    }
}
