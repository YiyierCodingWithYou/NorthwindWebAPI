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

		public Task<IEnumerable<Product>> Get()
		{
			throw new NotImplementedException();
		}
	}
}
