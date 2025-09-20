using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Models.Identity;
using Shared.DaraTransferObject.IdentityDtos;

namespace Service.MappingProfiels
{
    public class IdentityProfile:Profile
    {


        public IdentityProfile() { 
        
        CreateMap<Address, AddressDto>().ReverseMap();


        }
    }
}
