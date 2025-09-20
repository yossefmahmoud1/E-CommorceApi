using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        IProductService productService { get; }

        IBasketServices BasketServices { get; }
        IAuthentacationService AuthentacationService { get; }

        IOrderService OrderService { get; }
        IPaymentService PaymentService{ get; }
    }
}
