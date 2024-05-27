using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Dto.OrderProducts;
using Ecommerce.Application.Dto.Orders;
using Ecommerce.Core.IRepositories.IOrder;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Queries.GetAllOrders
{
	public class GetAllOrdersQueryHandler(ILogger<GetAllOrdersQueryHandler> logger,
		IOrderRepository ordersRepository,
		IMapper mapper) : IRequestHandler<GetAllOrdersQuery, PagedResult<OrderDto>>
	{
		public async Task<PagedResult<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Getting all Orders");

			var (orders, totalCount) = await ordersRepository.GetAllAsync(request.Keyword, request.PageSize, request.PageNumber, request.SortBy, request.SortDirection);

			var ordersDtos = orders.Select(x => new OrderDto
			{
				Id = x.Id,
				DeliveryAdress = x.DeliveryAdress,
				CustomerId = x.CustomerId,
				DeliveryTime = x.DeliveryTime,
				CustomerName = x.Customer.Name,
				CustomerEmail = x.Customer.Email,
				CustomerContactNumber = x.Customer.ContactNumber,
				TotalPrice = x.OrderProducts.Sum(x => x.Quantity * x.Product.Price),
				OrderProducts = x.OrderProducts.Select(op => new OrderProductDto
				{
					ProductId = op.ProductId,
					ProductName = op.Product != null ? op.Product.ProductName : null,
					ProductQuantity = op.Quantity
				}).ToList()
			});

			var result = new PagedResult<OrderDto>(ordersDtos, totalCount, request.PageSize, request.PageNumber);
			return result;

		}
	}
}
