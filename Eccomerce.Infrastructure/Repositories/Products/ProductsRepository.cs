using Ecommerce.Core.Entities.Products;
using Ecommerce.Core.IRepositories.IProduct;
using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories.Products
{
	public class ProductsRepository(EcommerceDbContext dbContext)
		: IProductsRepository
	{
		public async Task<int> Create(Product product)
		{
			dbContext.Products.Add(product);
			await dbContext.SaveChangesAsync();
			return product.Id;
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			var products = await dbContext.Products.ToListAsync();
			return products;
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
			return product;
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
