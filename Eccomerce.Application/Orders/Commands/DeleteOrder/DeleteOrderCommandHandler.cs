using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.IRepositories.IOrder;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandHandler(ILogger<DeleteOrderCommandHandler> logger,
		IOrderRepository ordersRepository) : IRequestHandler<DeleteOrderCommand>
	{
		public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation($"Deleting Order with id : {request.Id}");

			var order = await ordersRepository.GetByIdAsync(request.Id);

			if(order is null)
				throw new NotFoundException(nameof(Order), request.Id.ToString());

			if (order.OrderProducts.Any())
				throw new OrderHasProductsException(request.Id.ToString());

			await ordersRepository.Delete(order);
		}
	}
}
