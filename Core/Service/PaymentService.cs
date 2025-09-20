using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Contracts;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Order;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction;
using Shared.BasketDtos;
using Stripe;

namespace Service
{
    public class PaymentService(IConfiguration configuration, IBasketRepository basketRepository, IUnitOfWork unitOfWork ,IMapper mapper) : IPaymentService
    {// Configure Stripe : Install Package Stripe.Net
     // Get Basket By BasketID
     // Get Amount - Get Product + Delivery Method Cost
     // Create Payment Intent [Create - Update]
        public async Task<BasketDto> CreateOrUpdatePayment(string BasketId)
        {

            {// Configure Stripe : Install Package Stripe.Net

                StripeConfiguration.ApiKey = configuration["StripeSettings:secretKey"];
                // Get Basket By BasketID

                var Basket = await basketRepository.GetCustomerBasketasync(BasketId) ?? throw new BasketNotFoundEx(BasketId);

                // Get Amount - Get Product + Delivery Method Cost
                var productRepo = unitOfWork.GetRepositery<Domain_Layer.Models.Producr.Product, int>();
                foreach (var item in Basket.BasketItems) {
                    var product = await productRepo.GetbyIDAsync(item.Id) ?? throw new ProductNotFoundEx(item.Id);
                    item.Price = product.Price;

                }
                ArgumentNullException.ThrowIfNull(Basket.deliveryMethodId);
                var DliveryMethod = await unitOfWork.GetRepositery<DlievryMethod, int>().GetbyIDAsync(Basket.deliveryMethodId.Value) ?? throw new DliveryMethodNotFoundEx(Basket.deliveryMethodId.Value);
                Basket.shippingPrice = DliveryMethod.Price;
                var BasketAmount =(long)( Basket.BasketItems.Sum(items => items.Quantity * items.Price) + DliveryMethod.Price ) * 100;


                var PaymentService = new PaymentIntentService();
                if (Basket.paymentIntentId is null) // Create
                {
                    var Options = new PaymentIntentCreateOptions()
                    {
                        Amount = BasketAmount,
                        Currency = "USD",
                        PaymentMethodTypes = ["card"]
                    };
                    var PaymentIntent = await PaymentService.CreateAsync(options: Options);
                    Basket.paymentIntentId = PaymentIntent.Id;
                    Basket.clientSecret = PaymentIntent.ClientSecret;
                }
                else // Update
                {
                    var Options = new PaymentIntentUpdateOptions() { Amount = BasketAmount };
                    await PaymentService.UpdateAsync(id: Basket.paymentIntentId, options: Options);
                }


                await basketRepository.CreateOrUpdateAsync(Basket);





                return mapper.Map<BasketDto>(Basket);




            }
        }
    }
}
