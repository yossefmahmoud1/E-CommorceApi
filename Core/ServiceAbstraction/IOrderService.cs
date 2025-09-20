using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Order;
using Domain_Layer.Models.Producr;
using Shared.OrderDtos;

namespace ServiceAbstraction
{
    public interface IOrderService
    {

        //Creating Order Will Take Basket Id, Shipping Address , Delivery Method Id , Customer Email
        //And Return Order Details
        //(Id , UserName , OrderDate , Items (Product Name - Picture Url - Price - Quantity) , Address , Delivery Method Name , Order Status Value , Sub Total, Total Price  )


        Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string email);

        Task<IEnumerable<DlievryMethodDto>> GetAllDliveryMethodAsync();
        Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string Email);

        Task<OrderToReturnDto> GetOrderByIdAsync(Guid Id);



    }
}
