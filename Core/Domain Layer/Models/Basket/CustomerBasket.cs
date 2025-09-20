using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; } //GUID :CREATED FROM FRONTEND
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public string? clientSecret { get; set; }
        public string? paymentIntentId { get; set; }
        public int? deliveryMethodId { get; set; }
        public decimal? shippingPrice { get; set; }
    }
}
