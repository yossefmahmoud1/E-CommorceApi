using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Models.Order;
using Services.MappingProfiles;
using Shared.DaraTransferObject.IdentityDtos;
using Shared.OrderDtos;

namespace Service.MappingProfiels
{
    public class OrderProfile:Profile
    {
        public OrderProfile() { 
        
        CreateMap<AddressDto, OrderAddress>()
            .ForMember(destinationMember: d => d.FirstName, memberOptions: o => o.MapFrom(s => s.FristName));

        // Return mapping for projecting Order.Address back to DTO
        CreateMap<OrderAddress, AddressDto>()
            .ForMember(destinationMember: d => d.FristName, memberOptions: o => o.MapFrom(s => s.FirstName));
            CreateMap<Order, OrderToReturnDto>()
    .ForMember(destinationMember: D => D.DeliveryMethod, memberOptions: O => O.MapFrom(mapExpression: s => s.DeliveryMethod.ShortName));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(destinationMember: D => D.ProductName, memberOptions: O => O.MapFrom(mapExpression: s => s.Product.ProductName))
                .ForMember(destinationMember: D => D.PuctireUrl, memberOptions: O => O.MapFrom<OrderItemPictureUrlResolver>());




            CreateMap<DlievryMethod, DlievryMethodDto>();

        }


    }
}
