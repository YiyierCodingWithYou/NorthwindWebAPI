using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindWebAPI.Infrastructure;
using NorthwindWebAPI.Models.Dtos;
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
			return Ok(await _productService.GetProductList());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
			var result = await _productService.GetProduct(id);
            if (result == null)
            {
                return NotFound("該商品不存在。");
            }
			return Ok(result);
            
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ApiResult> PutProduct(int id, ProductDto product)
        {
            var result = await _productService.Update(id,product);
			if (result.IsFail)
			{
				return ApiResult.Fail(result.Message);
			}
			return ApiResult.Success(result.Message);
		}

        // POST: api/Products
        [HttpPost]
        public async Task<ApiResult> PostProduct(ProductDto product)
        {
            var result = await _productService.Create(product);
            if (result.IsFail)
            {
                return ApiResult.Fail(result.Message);
            }
            return ApiResult.Success(result.Message);
		}

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (result.IsFail)
            {
                return ApiResult.Fail(result.Message);
            }
            return ApiResult.Success(result.Message);
		}

    }
}
