using MarketFlow.Core.Dtos;
using MarketFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketFlow.Api.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {

        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of products.</returns>

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _productServices.GetAllProducts();

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Gets a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product with the specified ID.</returns>

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _productServices.GetProductById(id);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }


        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="productForCreationDto">The product to create.</param>
        /// <returns>The created product.</returns>
        
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductForCreationDto productForCreationDto)
        {
            var response = await _productServices.CreateProduct(productForCreationDto);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="productForUpdateDto">The updated product data.</param>
        /// <returns>The updated product.</returns>

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(long id, ProductForCreationDto productForCreationDto)
        {
            var response = await _productServices.UpdateProduct(id, productForCreationDto);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>The deleted product.</returns>

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _productServices.DeleteProduct(id);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

    }
}
