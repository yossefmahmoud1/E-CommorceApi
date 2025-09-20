﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain_Layer.Models.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string DisplayName { get; set; } = default!;
        public Address? Address { get; set; }
   





    }
}
