using Ecommerce.Core.Entities.Products;

namespace Ecommerce.Core.IRepositories.IProduct
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> Create(Product product);
        bool IsNameExists(string name);
        Task Delete(Product product);
        Task SaveChanges();

	}
}
