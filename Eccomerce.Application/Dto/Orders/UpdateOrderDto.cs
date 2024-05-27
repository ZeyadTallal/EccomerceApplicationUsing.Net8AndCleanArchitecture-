using Ecommerce.Application.Dto.OrderProducts;
using Ecommerce.Core.Entities.Customers;
using Ecommerce.Core.Entities.OrderProducts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Application.Dto.Orders
{
	public class UpdateOrderDto
	{
		public string DeliveryAdress { get; set; } 
		public int CustomerId { get; set; }
		public DateTime DeliveryTime { get; set; }
		public ICollection<OrderProductDto> OrderProducts { get; set; }
	}
}
