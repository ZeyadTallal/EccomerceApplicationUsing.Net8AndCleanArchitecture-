using Ecommerce.Core.Entities.Customers;
using Ecommerce.Core.Entities.OrderProducts;
using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Context
{
	public class EcommerceDbContext : DbContext
	{
		public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
		{

		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
