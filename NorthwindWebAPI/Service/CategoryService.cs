using NorthwindWebAPI.Infrastructure.Interface;
using NorthwindWebAPI.Models.EFModels;

namespace NorthwindWebAPI.Infrastructure.Service
{
	public class CategoryService : ICategoryRepository
	{
		private AppDbContext db = new AppDbContext();

		public CategoryService()
		{

		}
	}
}
