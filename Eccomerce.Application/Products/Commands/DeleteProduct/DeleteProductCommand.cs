using MediatR;

namespace Ecommerce.Application.Products.Commands.DeleteProduct
{
	public class DeleteProductCommand(int id) : IRequest
	{
		public int Id { get; set; } = id;
	}
}
