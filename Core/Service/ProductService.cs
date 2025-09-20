using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Contracts;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Producr;
using Service.Specification;
using ServiceAbstraction;
using Shared;
using Shared.DaraTransferObject;
using Shared.ProductDtos;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductBrandDto>> GetAllBrands()
        {
            var Repo = unitOfWork.GetRepositery<ProductBrand, int>();

            var Brands = await Repo.GetAllAsync();
            var BrandsDto = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<ProductBrandDto>>(Brands);

            return BrandsDto;

        }

        public async Task<PaginatedReponse<ProductDto>> GetAllProducts(ProductGetAllParams QueryParams)
        {
            var Repo= unitOfWork.GetRepositery<Product , int>();
            var specification = new ProductWithBrandAndTypeSpecification(QueryParams);
            var AllProducts = await Repo.GetAllAsync(specification);
            var Data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(AllProducts);
            var CountSpec = new ProductCountspecifications(QueryParams);
            var TotalCount=await Repo.CountAsync(CountSpec);
            return new PaginatedReponse<ProductDto>(QueryParams.PageIndex, QueryParams.PageSize, TotalCount, Data);
        }

        public async Task<IEnumerable<ProductTypesDto>> GetAllTtpes()
        {
            var Types = await unitOfWork.GetRepositery<ProductType, int>().GetAllAsync();
            var TypesDto = mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypesDto>>(Types);
            return TypesDto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var specification = new ProductWithBrandAndTypeSpecification(id);

            var product = await unitOfWork.GetRepositery<Product, int>().GetbyIDAsync(specification);
            if(product is null)
            {
                throw new ProductNotFoundEx(id);
            }
            return mapper.Map<Product, ProductDto>(product);
        }
         
        public async Task<ProductDto> CreateProduct(ProductCreateDto productDto)
        {
            var repo = unitOfWork.GetRepositery<Product, int>();
            var entity = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                PictureUrl = productDto.PictureUrl,
                BrandId = productDto.BrandId,
                TypeId = productDto.TypeId
            };
            await repo.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto> UpdateProductById(int id, ProductDto productDto)
        {
            var repo = unitOfWork.GetRepositery<Product, int>();
            var product = await repo.GetbyIDAsync(id);
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.PictureUrl = productDto.PictureUrl;
            // Note: Brand/Type updates would need lookup by names; kept simple here
            repo.Update(product);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var repo = unitOfWork.GetRepositery<Product, int>();
            var product = await repo.GetbyIDAsync(id);
            repo.Delete(product);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
