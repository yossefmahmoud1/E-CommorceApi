using System.ComponentModel.DataAnnotations;

namespace Shared.BasketDtos
{
    public class BasketItemDto
    {
        public required int Id { get; set; }
        public required string ProductName { get; set; }
        public required string PictureUrl { get; set; }

        [Range(1, double.MaxValue)]
        public required decimal Price { get; set; }

        [Range(1, 100)]
        public required int Quantity { get; set; }
    }
}