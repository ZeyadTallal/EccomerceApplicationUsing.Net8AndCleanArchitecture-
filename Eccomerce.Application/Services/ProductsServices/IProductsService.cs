using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.Entities.Products;

namespace Ecommerce.Application.Services.ProductsServices
{
	public interface IProductsService
	{
		Task<IEnumerable<ProductDto>> GetAllProducts();
		Task<ProductDto> GetProductById(int id);
		Task<int> CreateProduct(CreateProductDto createProductDto);
	}
}
