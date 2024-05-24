using AutoMapper;
using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.Entities.Products;
using Ecommerce.Core.IRepositories.IProduct;

namespace Ecommerce.Application.Services.ProductsServices
{
	public class ProductsService(IProductsRepository productsRepository,IMapper mapper) : IProductsService
	{
		

		public async Task<IEnumerable<ProductDto>> GetAllProducts()
		{
			var products = await productsRepository.GetAllAsync();
			var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);
			return productsDtos;
		}

		public async Task<ProductDto> GetProductById(int id)
		{
			var product = await productsRepository.GetByIdAsync(id);
			var productDto = mapper.Map<ProductDto>(product);
			return productDto;
		}
		public async Task<int> CreateProduct(CreateProductDto createProductDto)
		{
			//var product = mapper.Map<Product>(createProductDto);
			using var stream = new MemoryStream();
			await createProductDto.ProductImage.CopyToAsync(stream);

			var product = new Product
			{

				ProductName = createProductDto.ProductName,
				ProductDescription = createProductDto.ProductDescription,
				Price = createProductDto.Price,
				Merchant = createProductDto.Merchant,
				ProductImage = stream.ToArray(),
			};

			int id = await productsRepository.Create(product);
			return id;
		}
	}
}
