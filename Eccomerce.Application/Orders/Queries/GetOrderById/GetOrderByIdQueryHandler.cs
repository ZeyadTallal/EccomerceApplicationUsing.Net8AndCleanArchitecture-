using AutoMapper;
using Ecommerce.Application.Dto.OrderProducts;
using Ecommerce.Application.Dto.Orders;
using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.IRepositories.IOrder;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Queries.GetOrderById
{
	public class GetOrderByIdQueryHandler(ILogger<GetOrderByIdQueryHandler> logger,
		IOrderRepository ordersRepository,
		IMapper mapper) : IRequestHandler<GetOrderByIdQuery, OrderDto>
	{
		public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			logger.LogInformation($"Getting Order by Id {request.Id}");

			var order = await ordersRepository.GetByIdAsync(request.Id)
				?? throw new NotFoundException(nameof(Order), request.Id.ToString());

			var orderDto = new OrderDto
			{
				Id = order.Id,
				DeliveryAdress = order.DeliveryAdress,
				CustomerId = order.CustomerId,
				DeliveryTime = order.DeliveryTime,
				CustomerName = order.Customer.Name,
				CustomerEmail = order.Customer.Email,
				CustomerContactNumber = order.Customer.ContactNumber,
				TotalPrice = order.OrderProducts.Sum(x => x.Quantity * x.Product.Price),
				OrderProducts = order.OrderProducts.Select(x => new OrderProductDto
				{
					ProductId = x.ProductId,
					ProductName = x.Product.ProductName,
					ProductQuantity = x.Quantity
				}).ToList()
			};

			return orderDto;
		}
	}
}
