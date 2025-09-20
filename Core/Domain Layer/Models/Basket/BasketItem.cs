using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Basket
{
    public class BasketItem
    {
        public required int Id { get; set; }
        public required string ProductName { get; set; }
        public required string PictureUrl { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }

    }
}
