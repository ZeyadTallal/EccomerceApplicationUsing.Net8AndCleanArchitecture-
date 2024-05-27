using Ecommerce.Application.Dto.Orders;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetOrderById
{
	public class GetOrderByIdQuery(int id) : IRequest<OrderDto>
	{
		public int Id { get; } = id;
	}
}
