using Ecommerce.Application.Dto.OrderProducts;
using Ecommerce.Core.Entities.OrderProducts;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<int>
	{
		[Required]
		public string DeliveryAdress { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public DateTime DeliveryTime { get; set; }
		[Required]
		public ICollection<OrderProductDto> OrderProducts { get; set; }
	}
}
