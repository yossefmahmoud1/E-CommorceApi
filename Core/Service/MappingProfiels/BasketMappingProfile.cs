using AutoMapper;
using Domain_Layer.Models.Basket;
using Shared.BasketDtos;

namespace Service.MappingProfiles
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(d => d.PictureUrl, opt => opt.MapFrom(src => src.PictureUrl))
                .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<BasketItemDto, BasketItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(d => d.PictureUrl, opt => opt.MapFrom(src => src.PictureUrl))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<CustomerBasket, BasketDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems));

            CreateMap<BasketDto, CustomerBasket>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems));
        }
    }
}
