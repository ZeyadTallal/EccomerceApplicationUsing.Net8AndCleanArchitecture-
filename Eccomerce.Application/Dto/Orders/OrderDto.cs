using Ecommerce.Application.Dto.OrderProducts;

namespace Ecommerce.Application.Dto.Orders
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string DeliveryAdress { get; set; } = string.Empty;
		public int CustomerId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime DeliveryTime { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; } = string.Empty;
		public string CustomerContactNumber { get; set; } = string.Empty;
		public ICollection<OrderProductDto> OrderProducts { get; set; }
	}
}
