using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models;
using Shared;

using Shared.DaraTransferObject;
using Shared.ProductDtos;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //get all products
        Task<PaginatedReponse<ProductDto>> GetAllProducts(ProductGetAllParams QueryParams);


        //get all Brands
        Task<IEnumerable<ProductBrandDto>> GetAllBrands();

        //get all Types
        Task<IEnumerable<ProductTypesDto>> GetAllTtpes();

        //get product BY id
        Task<ProductDto> GetProductById(int id);

        //create new product
        Task<ProductDto> CreateProduct(ProductCreateDto product);

        //update product by id
        Task<ProductDto> UpdateProductById(int id, ProductDto product);

        //delete product by id
        Task<bool> DeleteProductById(int id);

    }
}
