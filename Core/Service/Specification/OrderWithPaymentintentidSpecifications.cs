using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Order;

namespace Service.Specification
{
     class OrderWithPaymentintentidSpecifications :BaseSpecifications<Order ,Guid>

    {
        public OrderWithPaymentintentidSpecifications(string PaymentIntnentId) : base( o => o.PaymentIntnentId == PaymentIntnentId)
        {
        }


    }
}
