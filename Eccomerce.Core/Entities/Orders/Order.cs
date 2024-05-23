using Ecommerce.Core.Entities.Customers;
using Ecommerce.Core.Entities.OrderProducts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities.Orders
{
	public class Order
	{
		public int Id { get; set; }
		public string DeliveryAdress { get; set; } = string.Empty;
		public decimal TotalCost { get; set; }
		public int CustomerId { get; set; }
		public DateTime DeliveryTime { get; set; }

		[ForeignKey(nameof(CustomerId))]
		public Customer Customer { get; set; }
		public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
	}
}
