using AutoMapper;
using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Queries.GetProductById
{
	public class GetProductByIdHandler(ILogger<GetProductByIdHandler> logger,
		IProductsRepository productsRepository,
		IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto?>
	{
		public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			logger.LogInformation($"Getting Product by Id {request.Id}");

			var product = await productsRepository.GetByIdAsync(request.Id);
			var productDto = mapper.Map<ProductDto>(product);
			return productDto;
		}
	}
}
