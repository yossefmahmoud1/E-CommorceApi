using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Models.Order
{
    public class DlievryMethod:BaseEntity<int>
    {

        public String ShortName { get; set; } = default!;
        public String Description { get; set; } = default!;
        public String DeliveryTime { get; set; } = default!;
        public Decimal Price { get; set; } 
     





    }
}
