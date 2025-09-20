﻿namespace Domain_Layer.Models.Identity
{
    public class Address
    {
        public  int Id { get; set; }

        public string FristName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

         
        public string UserId { get; set; } = default!;


    }
}