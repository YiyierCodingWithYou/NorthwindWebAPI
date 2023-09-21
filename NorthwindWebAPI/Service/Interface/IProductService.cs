using NorthwindWebAPI.Infrastructure;
using NorthwindWebAPI.Models.Dtos;
using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Service.Interface
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProductList();

		Task<Product> GetProduct(int id);

		Task<ApiResult> Delete(int id);

		Task<ApiResult> Create(ProductDto dto);
		Task<ApiResult> Update(int id,ProductDto dto);
	}
}
