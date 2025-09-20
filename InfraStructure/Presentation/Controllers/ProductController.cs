using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DaraTransferObject;
using Shared.ProductDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]//baseurl//api//products
    public class ProductController(IServiceManager _serviceManager) :ControllerBase
    {
        //Get All Products


        [HttpGet]
        [Cache]
        public async Task <ActionResult<PaginatedReponse<ProductDto>>> GetAllProducts([FromQuery]ProductGetAllParams QueryParams) 
        {


         var products=await   _serviceManager.productService.GetAllProducts(QueryParams);

            return Ok(products);

        }

        [HttpPost] 
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductCreateDto product)
        {
            if (product is null) return BadRequest();
            var created = await _serviceManager.productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")] 
        public async Task <ActionResult<ProductDto>> GetProductById(int id)
        {
            var product= await _serviceManager.productService.GetProductById(id);

            return Ok(product);


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (product is null || product.Id != 0 && product.Id != id) return BadRequest();
            var updated = await _serviceManager.productService.UpdateProductById(id, product);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deleted = await _serviceManager.productService.DeleteProductById(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        
        
        [HttpGet("types")] //baseurl//api//products/Types
        public async Task <ActionResult<IEnumerable<ProductTypesDto> >> GetAllTypes()
        {
            var Types= await _serviceManager.productService.GetAllTtpes();

            return Ok(Types);


        }   
        [HttpGet("brands")] //baseurl//api//products/brands
        [Cache]

        public async Task <ActionResult<IEnumerable<ProductBrandDto> >> GetAllBrands()
        {
            var Brands= await _serviceManager.productService.GetAllBrands();

            return Ok(Brands);


        }




    }
}
