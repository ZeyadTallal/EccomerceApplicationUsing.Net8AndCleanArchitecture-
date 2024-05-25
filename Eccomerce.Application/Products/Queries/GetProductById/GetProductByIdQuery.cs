using Ecommerce.Application.Dto.Products;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProductById
{
	public class GetProductByIdQuery(int id) : IRequest<ProductDto>
	{
        public int Id { get; } = id;
    }
}
