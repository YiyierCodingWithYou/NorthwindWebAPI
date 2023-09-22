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
		private readonly string _connStr;
		public ProductRepository(AppDbContext context,IConfiguration configuration)
		{
			_context = context;
			_connStr = configuration.GetConnectionString("DefaultConnection");
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

		public async Task<bool> Update(ProductDto dto)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"UPDATE Products SET 
ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, 
QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice,UnitsInStock = @UnitsInStock, 
UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued
WHERE ProductID = @ProductID";
				var rowAffected = await conn.ExecuteAsync(sql, dto);
				return rowAffected > 0;
			}

		}

		public async Task<bool> Delete(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return false;
			}
			try
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				return false;
			}
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
			return products.AsEnumerable();
		}


	}
}
