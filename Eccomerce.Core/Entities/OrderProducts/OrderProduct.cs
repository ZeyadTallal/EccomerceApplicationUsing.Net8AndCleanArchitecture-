using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Entities.Products;

namespace Ecommerce.Core.Entities.OrderProducts
{
	public class OrderProduct
	{
		//public int Id { get; set; }
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
		public Order Order { get; set; }
	}
}
