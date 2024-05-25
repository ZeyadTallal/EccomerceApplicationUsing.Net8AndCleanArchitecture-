using AutoMapper;
using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
	public class GetAllProductsHandler(ILogger<GetAllProductsHandler> logger,
		IProductsRepository productsRepository,
		IMapper mapper ) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
	{
		public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Getting all Products");

			var products = await productsRepository.GetAllAsync();
			var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);
			return productsDtos;
		}
	}
}
