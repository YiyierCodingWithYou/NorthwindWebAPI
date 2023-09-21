using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Infrastructure.Interface
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProductList();

		Task<Product> GetProduct(int id);

		Task<bool> Delete(int id);
	}
}
