using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;
using Shared.ProductDtos;

namespace Service.Specification
{
     class ProductWithBrandAndTypeSpecification:BaseSpecifications<Product,int>
    {


        public ProductWithBrandAndTypeSpecification(ProductGetAllParams QueryParams)
            
            : base( p=> (!QueryParams.BrandId.HasValue || p.BrandId == QueryParams.BrandId) &&
                 (!QueryParams.TypeId.HasValue || p.TypeId== QueryParams.TypeId) && 
            (string.IsNullOrWhiteSpace(QueryParams.SearchValue) || p.Name.ToLower()  .Contains(QueryParams.SearchValue.ToLower()) ) )
 
        //where(p=>p.Brandid == BrandId // p=>p.TypeId == TypeId)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType) ;

            switch (QueryParams.SortingOption)
            {
                case ProductSortingOptions.NameAsc: AddOrderby(p => p.Name);
                        break;





                case ProductSortingOptions.NameDesc:
                    AddOrderbyDes(p => p.Name);
                    break;





                case ProductSortingOptions.PriceAsc: AddOrderby(p => p.Price);
                        break;





                case ProductSortingOptions.PriceDesc:
                    AddOrderbyDes(p => p.Price);
                    break;

                default:
                    break;

            }

            ApplyPagination(QueryParams.PageSize, QueryParams.PageIndex);

        }







        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }



    }
}
