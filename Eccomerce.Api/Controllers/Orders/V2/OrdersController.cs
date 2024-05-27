using Asp.Versioning;
using Ecommerce.Application.Dto.OrderProducts;
using Ecommerce.Application.Dto.Orders;
using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Commands.DeleteOrder;
using Ecommerce.Application.Orders.Commands.UpdateOrder;
using Ecommerce.Application.Orders.Queries.GetAllOrders;
using Ecommerce.Application.Orders.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.Orders.V2
{
	[ApiController]
	[ApiVersion(2)]
	[Route("api/v{version:apiVersion}/[controller]/[action]")]
	public class OrdersController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll([FromQuery] GetAllOrdersQuery query)
		{
			var orders = await mediator.Send(query);
			return Ok(orders);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderDto?>> GetById([FromRoute] int id)
		{
			var order = await mediator.Send(new GetOrderByIdQuery(id));

			return Ok(order);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateOrderCommand input)
		{
			int id = await mediator.Send(input);
			return CreatedAtAction(nameof(GetById), new { id }, null);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await mediator.Send(new DeleteOrderCommand(id));

			return NoContent();
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> Update(int id, UpdateOrderDto input)
		{
			var updateOrderCommand = new UpdateOrderCommand()
			{
				Id = id,
				DeliveryAdress = input.DeliveryAdress,
				CustomerId = input.CustomerId,
				DeliveryTime = input.DeliveryTime,
				OrderProducts = input.OrderProducts.Select(x=> new OrderProductDto
				{
					ProductId = x.ProductId,
					ProductQuantity = x.ProductQuantity
				}).ToList()
			};

			await mediator.Send(updateOrderCommand);

			return NoContent();
		}
	}
}
