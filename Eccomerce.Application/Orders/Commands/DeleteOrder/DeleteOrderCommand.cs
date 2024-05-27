using MediatR;

namespace Ecommerce.Application.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommand(int id) : IRequest
	{
		public int Id { get; set; } = id;
	}
}
