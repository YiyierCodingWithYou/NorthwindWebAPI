using NorthwindWebAPI.Models.Dtos;
using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Infrastructure.Interface
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProductList();

		Task<Product> GetProduct(int id);

		Task<bool> Delete(int id);

		Task<bool> Create(ProductDto dto);

		Task<bool> Update(ProductDto dto);
	}
}
