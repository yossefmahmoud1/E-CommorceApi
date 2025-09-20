﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DaraTransferObject.IdentityDtos;

namespace Shared.OrderDtos
{
    public class OrderToReturnDto
    {
        public Guid id { get; set; }
        public string UserEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; }
        public AddressDto Address { get; set; } = default!;
        public string DeliveryMethod { get; set; } = default!;
        public string OrderStatus { get; set; } = default!;
        public ICollection<OrderItemDto> Items { get; set; } = [];

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; } 


    }
}
