using NorthwindWebAPI.Infrastructure.Interface;
using NorthwindWebAPI.Models.Dtos;
using NorthwindWebAPI.Models.EFModels;
using NorthwindWebAPI.Service.Interface;

namespace NorthwindWebAPI.Infrastructure.Service
{
	public class ProductService:IProductService
	{
		private readonly IProductRepository _repo;
		public ProductService(IProductRepository repo)
		{
			_repo = repo;
		}

		public async Task<ApiResult> Create(ProductDto dto)
		{
			var result =await _repo.Create(dto);
			if (!result)
			{
				return ApiResult.Fail("商品新增失敗。");
			}
			return ApiResult.Success("商品新增成功");
		}

		public async Task<ApiResult> Delete(int id)
		{
			var result = await _repo.Delete(id);
			if (!result)
			{
				return ApiResult.Fail("該商品不存在或與其他資料有關聯，刪除失敗。");
			}
			return ApiResult.Success("刪除成功。");
		}

		public async Task<Product> GetProduct(int id)
		{
			var result =await _repo.GetProduct(id);
			return result;
		}

		public async Task<IEnumerable<Product>> GetProductList()
		{
			
			var result = await _repo.GetProductList();
			return result;
		}

		public async Task<ApiResult> Update(int id,ProductDto dto)
		{
			var product = await _repo.GetProduct(id);
			if (product == null)
			{
				return ApiResult.Fail("該商品不存在。");
			}
			var updateProduct = new ProductDto()
			{
				ProductId = dto.ProductId,
				ProductName = dto.ProductName,
				SupplierId = dto.SupplierId,
				CategoryId = dto.CategoryId,
				QuantityPerUnit = dto.QuantityPerUnit,
				UnitPrice = dto.UnitPrice,
				UnitsInStock = dto.UnitsInStock,
				UnitsOnOrder = dto.UnitsOnOrder,
				ReorderLevel = dto.ReorderLevel,
				Discontinued = dto.Discontinued
			};
			var result = await _repo.Update(updateProduct);
			if (!result)
			{
				return ApiResult.Fail("商品更新失敗。");
			}
			return ApiResult.Success("商品更新成功。");
		}
	}
}
