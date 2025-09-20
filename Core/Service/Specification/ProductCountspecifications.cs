using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;
using Shared.ProductDtos;

namespace Service.Specification
{
     class ProductCountspecifications:BaseSpecifications<Product ,int>
    {
        public ProductCountspecifications(ProductGetAllParams QueryParams) : base(p => (!QueryParams.BrandId.HasValue || p.BrandId == QueryParams.BrandId) &&
                 (!QueryParams.TypeId.HasValue || p.TypeId == QueryParams.TypeId) &&
            (string.IsNullOrWhiteSpace(QueryParams.SearchValue) || p.Name.ToLower().Contains(QueryParams.SearchValue.ToLower())))
        {


        }
    }
}
