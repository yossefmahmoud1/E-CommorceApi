using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Models.Order
{
    public class Order: BaseEntity<Guid>
    {
        // Parameterless constructor for EF Core design-time operations
        public Order()
        {
        }

        // Parameterized constructor for application use
        public Order(string userEmail, OrderAddress address, DlievryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal ,string paymentIntnentId = "")
        {
            UserEmail = userEmail;
            Address = address;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
            PaymentIntnentId = paymentIntnentId;

        }

        public string UserEmail { get; set; } = default!;
        public OrderAddress Address { get; set; } = default!; public DlievryMethod DeliveryMethod { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = [];

        public decimal SubTotal { get; set; }

        public DateTimeOffset OrderDate { get; set; } =DateTimeOffset.Now;
        public OrderStatus OrderStatus { get; set; }

        public int DlievryMethodid { get; set; }
        //[NotMapped]
        //public decimal Total { get => SubTotal + DlievryMethod.Price; }

        public decimal GetTotal() => SubTotal + (DeliveryMethod?.Price ?? 0);

        public string PaymentIntnentId { get; set; }

    }
}
