using Ecommerce.Application.Common;
using Ecommerce.Application.Dto.Orders;
using Ecommerce.Core.Constants;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetAllOrders
{
	public class GetAllOrdersQuery : IRequest<PagedResult<OrderDto>>
	{
		public string? Keyword { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string? SortBy { get; set; }
		public SortDirection SortDirection { get; set; }
	}
}
