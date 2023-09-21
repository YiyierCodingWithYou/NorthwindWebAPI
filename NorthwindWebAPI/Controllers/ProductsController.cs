using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindWebAPI.Models.EFModels;
using NorthwindWebAPI.Service.Interface;

namespace NorthwindWebAPI.Controllers
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

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {            
            var result = await _productService.GetProductList();
			return Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            return Ok();
		}

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
			throw new NotImplementedException();
		}

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
			throw new NotImplementedException();
		}

    }
}
