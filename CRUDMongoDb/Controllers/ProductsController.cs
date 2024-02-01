using CRUDMongoDb.Models;
using CRUDMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{productId:length(24)}")]
        public async Task<ActionResult<Product>> Get(string productId)
        {
            var productDetails = await _productService.GetByIdAsync(productId);
            if (productDetails == null)
            {
                return NotFound();
            }
            return productDetails;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(Get), new { productId = product.Id }, product);
        }

        [HttpPut("{productId:length(24)}")]
        public async Task<IActionResult> Update(string productId, Product productDetails)
        {
            var existingProduct = await _productService.GetByIdAsync(productId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            productDetails.Id = existingProduct.Id;
            await _productService.UpdateAsync(productId, productDetails);
            return Ok();
        }

        [HttpDelete("{productId:length(24)}")]
        public async Task<IActionResult> Delete(string productId)
        {
            var productDetails = await _productService.GetByIdAsync(productId);
            if (productDetails == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(productId);
            return Ok();
        }
    }
}
