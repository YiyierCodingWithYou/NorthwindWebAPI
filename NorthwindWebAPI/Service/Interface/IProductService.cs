using NorthwindWebAPI.Infrastructure;
using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Service.Interface
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProductList();

		Task<Product> GetProduct(int id);

		Task<bool> Delete(int id);
	}
}
