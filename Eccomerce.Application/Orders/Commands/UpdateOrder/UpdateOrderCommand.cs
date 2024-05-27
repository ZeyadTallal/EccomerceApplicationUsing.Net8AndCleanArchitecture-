using Ecommerce.Application.Dto.OrderProducts;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommand : IRequest
	{
		public int Id { get; set; }
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
