using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities.OrderProducts
{
	public class OrderProduct
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public int Quantity { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; }

		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; }
	}
}
