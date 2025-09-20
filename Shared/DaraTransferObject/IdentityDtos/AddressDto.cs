using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DaraTransferObject.IdentityDtos
{
    public class AddressDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string FristName { get; set; } = default!;
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; } = default!;
        [System.ComponentModel.DataAnnotations.Required]
        public string Street { get; set; } = default!;
        [System.ComponentModel.DataAnnotations.Required]
        public string City { get; set; } = default!;
        [System.ComponentModel.DataAnnotations.Required]
        public string Country { get; set; } = default!;
    }
}
