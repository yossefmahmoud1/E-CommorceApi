﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Producr
{
    public class ProductType:BaseEntity<int>
    {
        public string Name { get; set; } = default!;

    }
}
