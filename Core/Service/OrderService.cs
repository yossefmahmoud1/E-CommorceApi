using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Contracts;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Order;
using Domain_Layer.Models.Producr;
using Service.Specification;
using ServiceAbstraction;
using Shared.DaraTransferObject.IdentityDtos;
using Shared.OrderDtos;

namespace Service
{
    public class OrderService(IMapper mapper, IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string Email)
        {
            //Map AddressDto To Order Address 
            //Get Basket By BasketID
            //Create OrderItemList
            //Get Dlivery Method
            //Calculate Sub Total Based On Items In Basket
            var OrderAddress = mapper.Map<AddressDto, OrderAddress>(orderDto.Address);
            var Basket = await basketRepository.GetCustomerBasketasync(orderDto.BasketId) ?? throw new BasketNotFoundEx(orderDto.BasketId);
            var orderSpecifications = new OrderWithPaymentintentidSpecifications(Basket.paymentIntentId);



            ArgumentNullException.ThrowIfNull(Basket.paymentIntentId);
            var orderrepo = unitOfWork.GetRepositery<Order, Guid>();
            var exiestingorder = await orderrepo.GetbyIDAsync(orderSpecifications);

            if (exiestingorder is not null) orderrepo.Delete(exiestingorder);


                List<OrderItem> orderItems = [];
            var ProductRepo = unitOfWork.GetRepositery<Product, int>();

            foreach (var item in Basket.BasketItems)
            {
                Product product;
                try
                {
                    product = await ProductRepo.GetbyIDAsync(item.Id);
                }
                catch (KeyNotFoundException)
                {
                    throw new ProductNotFoundEx(item.Id);
                }
                var orderItem = new OrderItem
                {
                    Product = new ProdectIremOrder
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        PuctireUrl = product.PictureUrl
                    },
                    Price = product.Price,
                    Quantity = item.Quantity
                };



                orderItems.Add(orderItem);
            }


            DlievryMethod DliveryMethod;
            try
            {
                DliveryMethod = await unitOfWork.GetRepositery<DlievryMethod, int>().GetbyIDAsync(orderDto.DeliveryMethodId);
            }
            catch (KeyNotFoundException)
            {
                throw new DliveryMethodNotFoundEx(orderDto.DeliveryMethodId);
            }


            var SubTotal = orderItems.Sum(I => I.Quantity * I.Price);

            var Order = new Order(Email, OrderAddress, DliveryMethod, orderItems, SubTotal , Basket.paymentIntentId );

            await unitOfWork.GetRepositery<Order, Guid>().AddAsync(Order);

            await unitOfWork.SaveChangesAsync();
            return mapper.Map<Order, OrderToReturnDto>(Order);

        }

        public async Task<IEnumerable<DlievryMethodDto>> GetAllDliveryMethodAsync()
        {
            var DliveryMethods = await unitOfWork.GetRepositery<DlievryMethod, int>().GetAllAsync();
            return mapper.Map<IEnumerable<DlievryMethod>, IEnumerable<DlievryMethodDto>>(DliveryMethods);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string Email)
        {
            var Spec = new OrderSpecifications(Email);
            var Orders = await unitOfWork.GetRepositery<Order, Guid>().GetAllAsync(Spec);


            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDto>>(Orders);


        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(Guid Id)
        {
            var Spec = new OrderSpecifications(Id);
            var Order = await unitOfWork.GetRepositery<Order, Guid>().GetbyIDAsync(Spec);

            return mapper.Map<OrderToReturnDto>(Order);
        }
    }
}
