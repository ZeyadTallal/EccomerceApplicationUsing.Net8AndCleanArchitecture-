using Ecommerce.Core.Entities.Orders;

namespace Ecommerce.Core.Entities.Customers
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string ContactNumber { get; set; } = string.Empty ;
		public ICollection<Order> Orders { get; set; } =  new HashSet<Order>();
	}
}
