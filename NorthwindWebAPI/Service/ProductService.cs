using NorthwindWebAPI.Infrastructure.Interface;
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

		public Task<Product> GetProduct(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Product>> GetProductList()
		{
			
			var result = await _repo.GetProductList();
			return result;
		}
	}
}
