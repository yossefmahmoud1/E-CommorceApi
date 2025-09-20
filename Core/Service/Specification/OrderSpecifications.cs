using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Order;

namespace Service.Specification
{
     class OrderSpecifications:BaseSpecifications<Order,Guid>
    {


        public OrderSpecifications(string Email):base (D =>D.UserEmail == Email)
        {
            AddInclude(O => O.DeliveryMethod);
            AddInclude(O => O.Items);
            AddOrderbyDes(O =>O.OrderDate);

        }
        public OrderSpecifications(Guid Id) : base(D => D.Id  == Id)
        {
            AddInclude(O => O.DeliveryMethod);
            AddInclude(O => O.Items);

        }



    }
}
