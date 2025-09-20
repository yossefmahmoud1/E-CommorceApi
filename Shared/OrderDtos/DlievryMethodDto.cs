using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderDtos
{
    public class DlievryMethodDto
    {
        public int Id { get; set; }

        public String ShortName { get; set; } = default!;
        public String Description { get; set; } = default!;
        public String DeliveryTime { get; set; } = default!;
        public Decimal Price { get; set; }

    }
}
