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

		public async Task<bool> Delete(int id)
		{
			var result = await _repo.Delete(id);
			return result;
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
	}
}
