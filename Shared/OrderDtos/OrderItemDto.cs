namespace Shared.OrderDtos
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } = default!;
        public string PuctireUrl { get; set; } = default!;
        public decimal price { get; set; }
        public int Qauntity { get; set; }
    }
}