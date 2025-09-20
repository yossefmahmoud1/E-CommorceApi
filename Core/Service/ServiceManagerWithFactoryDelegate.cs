using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAbstraction;

namespace Service
{
    public class ServiceManagerWithFactoryDelegate (Func<IProductService> ProductFactory ,

        Func<IBasketServices> BasketFactory, 
        Func<IAuthentacationService> AuthentacationFactory, 
        Func<IOrderService> OrderFactory,
        Func<IPaymentService> PaymentFactory



        ) : IServiceManager
    {
        public IProductService productService => ProductFactory.Invoke();

        public IBasketServices BasketServices => BasketFactory.Invoke();

        public IAuthentacationService AuthentacationService => AuthentacationFactory.Invoke();

        public IOrderService OrderService => OrderFactory.Invoke();



        public IPaymentService PaymentService => PaymentFactory.Invoke();



    }
}
