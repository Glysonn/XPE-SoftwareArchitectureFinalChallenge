using Microsoft.AspNetCore.Mvc;
using ProdManager.Application.DTOs;
using ProdManager.Application.Interfaces;

namespace ProdManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllProducts() 
        {
            var products = productService.FindAllProducts();
            return Ok(products); 
        }
        
        [HttpGet("GetById/{id:guid}")]
        public IActionResult GetProductById(Guid id)
        {
            var productDto = productService.FindProductById(id);
            if (productDto == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(productDto);
        }

        [HttpGet("GetByName")]
        public IActionResult GetProductsByName([FromQuery] string name)
        {
            var products = productService.FindProductsByName(name);
            return Ok(products);
        }
        
        [HttpGet("Count")]
        public IActionResult CountProducts()
        {
            var count = productService.CountProducts();
            return Ok(count);
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            productService.CreateProduct(dto);
            return Ok("Product created successfully.");
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody] UpdateProductDto dto)
        {
            productService.UpdateProduct(dto);
            return Ok("Product updated successfully.");
        }

        [HttpDelete("Delete/{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            productService.DeleteProduct(id);
            return Ok("Product deleted successfully.");
        }
    }
}