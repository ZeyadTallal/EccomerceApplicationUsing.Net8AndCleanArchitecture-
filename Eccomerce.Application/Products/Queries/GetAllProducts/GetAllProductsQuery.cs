using Ecommerce.Application.Dto.Products;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
	public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
	{
	}
}
