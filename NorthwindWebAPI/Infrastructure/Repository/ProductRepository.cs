using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthwindWebAPI.Infrastructure.Interface;
using NorthwindWebAPI.Models.Dtos;
using NorthwindWebAPI.Models.EFModels;
using Dapper;

namespace NorthwindWebAPI.Infrastructure.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		private readonly string _connStr = @"Server=(LocalDB)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";
		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(ProductDto dto)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO Products
(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice,
UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
VALUES
(@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice,
@UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);";
				var rowAffected = await conn.ExecuteAsync(sql, dto);
				return rowAffected > 0;
			}
		}

		public async Task<bool> Delete(int id)
		{
			var product = _context.Products.Find(id);
			if (product == null)
			{
				return false;
			}
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<Product> GetProduct(int id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
			return product;
		}

		public async Task<IEnumerable<Product>> GetProductList()
		{
			var products = await _context.Products.ToListAsync();
			if (products == null)
			{
				return Enumerable.Empty<Product>();
			}
			return products.AsEnumerable();
		}
	}
}
