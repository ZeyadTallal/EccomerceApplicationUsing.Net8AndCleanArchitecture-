using Ecommerce.Core.Entities.OrderProducts;
using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.IRepositories.IOrder;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, 
		IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, int>
	{
		public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Creating a new Order {@Order}", request);

			var order = new Order
			{
				DeliveryAdress = request.DeliveryAdress,
				CustomerId = request.CustomerId,
				DeliveryTime = request.DeliveryTime,
				OrderProducts = request.OrderProducts.Select(x => new OrderProduct
				{
					ProductId = x.ProductId,
					Quantity = x.ProductQuantity,
				}).ToList(),
			};

			var id = await orderRepository.Create(order);
			return id;
		}
	}
}
