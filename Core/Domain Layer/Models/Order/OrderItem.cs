﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Models.Order
{
    public class OrderItem:BaseEntity<int>
    {
        public ProdectIremOrder Product { get; set; }=default!; 

        public decimal Price { get; set; }
         public int Quantity { get; set; }
    }
}
