using System;

namespace Shared.DaraTransferObject
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public int BrandId { get; set; }
        public int TypeId { get; set; }
    }
}


