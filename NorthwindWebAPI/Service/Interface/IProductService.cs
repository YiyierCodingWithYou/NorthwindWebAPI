using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Service.Interface
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> Get();
	}
}
