using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Models.Producr;
using Microsoft.Extensions.Options;
using Shared.DaraTransferObject;

namespace Service.MappingProfiels
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<PuciterUrlRessolver>());



            CreateMap<ProductType, ProductTypesDto>();
            CreateMap<ProductBrand, ProductBrandDto>();













        }


    }
}
