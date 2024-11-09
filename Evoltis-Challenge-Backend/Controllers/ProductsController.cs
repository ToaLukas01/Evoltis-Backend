using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interfaces;

namespace Evoltis_Challenge_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsList()
        {
            var products = await _productsService.GetListProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var product = await _productsService.GetProductDetail(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsService.DeleteProduct(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct([FromBody] ProductoDTO productDTO)
        {
            var createdProduct = await _productsService.NewProduct(productDTO);
            return CreatedAtAction(nameof(GetProductDetail), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductoDTO productDTO)
        {
            var updatedProduct = await _productsService.UpdateProduct(id, productDTO);
            return Ok(updatedProduct);
        }
    }
}
