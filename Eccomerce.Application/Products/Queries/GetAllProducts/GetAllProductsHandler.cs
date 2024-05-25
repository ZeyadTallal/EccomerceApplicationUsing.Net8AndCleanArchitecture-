using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
	public class GetAllProductsHandler(ILogger<GetAllProductsHandler> logger,
		IProductsRepository productsRepository,
		IMapper mapper ) : IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
	{
		public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Getting all Products");

			var (products,totalCount) = await productsRepository.GetAllAsync(request.Keyword, request.PageSize , request.PageNumber,request.SortBy , request.SortDirection);
			var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);

			var result = new PagedResult<ProductDto>(productsDtos , totalCount , request.PageSize , request.PageNumber);
			return result;
		}
	}
}
