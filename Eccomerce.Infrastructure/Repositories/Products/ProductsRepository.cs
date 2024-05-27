using Ecommerce.Core.Constants;
using Ecommerce.Core.Entities.Products;
using Ecommerce.Core.IRepositories.IProduct;
using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Repositories.Products
{
	public class ProductsRepository(EcommerceDbContext dbContext)
		: IProductsRepository
	{
		public async Task<(IEnumerable<Product>,int)> GetAllAsync(string? Keyword , int pageSize, int pageNumber , string? sortBy , SortDirection sortDirection)
		{
			var searchByValue = Keyword?.ToLower();

			var query = dbContext.Products
				.Where(r => searchByValue == null ||
						(r.ProductName.ToLower().Contains(searchByValue) || r.ProductDescription.ToLower().Contains(searchByValue)));

			var totalCount = await query.CountAsync();

			if(sortBy != null)
			{
				var columnSelector = new Dictionary<string, Expression<Func<Product , object>>>
				{
					{nameof(Product.ProductName),r=> r.ProductName},
					{nameof(Product.Price),r=> r.Price},
				};

				var selectedColumn = columnSelector[sortBy];

				query = sortDirection == SortDirection.Ascending 
					? query.OrderBy(selectedColumn)
					: query.OrderByDescending(selectedColumn);
			}
			var products = await query
				.Skip(pageSize * (pageNumber-1))
				.Take(pageSize)
				.ToListAsync();

			return (products,totalCount);
		}
		public async Task<Product> GetByIdAsync(int id)
		{
			var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
			return product;
		}
		public async Task<int> Create(Product product)
		{
			dbContext.Products.Add(product);
			await dbContext.SaveChangesAsync();
			return product.Id;
		}
		public async Task Delete(Product product)
		{
			dbContext.Remove(product);
			await dbContext.SaveChangesAsync();
		}
		public bool IsNameExists(string name)
		{
			var isExisted = dbContext.Products.Any(x => x.ProductName == name);
			return isExisted;
		}
		public async Task SaveChanges() => await dbContext.SaveChangesAsync();
	}
}
