using Ecommerce.Core.Entities.OrderProducts;
using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.IRepositories.IOrder;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler(ILogger<UpdateOrderCommandHandler> logger,
		IOrderRepository ordersRepository) : IRequestHandler<UpdateOrderCommand>
	{
		public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Updating Order with id : {ProductId} with {@UpdateProduct}", request.Id, request);
			var order = await ordersRepository.GetByIdAsync(request.Id);

			if (order is null)
				throw new NotFoundException(nameof(Order), request.Id.ToString());

			order.DeliveryAdress = request.DeliveryAdress;
			order.CustomerId = request.CustomerId;
			order.DeliveryTime = request.DeliveryTime;
			order.OrderProducts = request.OrderProducts.Select(x => new OrderProduct
			{
				ProductId = x.ProductId,
				Quantity = x.ProductQuantity
			}).ToList();

			await ordersRepository.SaveChanges();
		}
	}
}
