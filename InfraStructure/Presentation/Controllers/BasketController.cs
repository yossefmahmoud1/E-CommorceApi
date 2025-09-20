using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceAbstraction;
using Shared.BasketDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManager serviceManager):ControllerBase
    {
        //GetBasket
        [HttpGet("{Key}")] //get/baseurl//api/basket/{Key}
        public async Task<ActionResult<BasketDto>> GetBasket([FromRoute] string Key) {

          var Basket= await serviceManager.BasketServices.GetBasketDto(Key);


            return Ok(Basket);


        }

        //Create Or Update

        [HttpPost]

        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {

            var Basket = await serviceManager.BasketServices.CreateOrUpdateBasket(basket);

            return Ok(Basket);



        }

        //Delete Basket

        [HttpDelete ("{Key}")]
        //get/baseurl//api/basket/key
        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {

            var Result = await serviceManager.BasketServices.DeleteBasketAsync(Key);

            return Ok(Result);



        }


    }
    }
