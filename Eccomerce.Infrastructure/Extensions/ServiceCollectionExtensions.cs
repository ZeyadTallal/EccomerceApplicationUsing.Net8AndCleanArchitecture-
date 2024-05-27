using Ecommerce.Core.IRepositories.IOrder;
using Ecommerce.Core.IRepositories.IProduct;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.Repositories.Orders;
using Ecommerce.Infrastructure.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("ConnectionString");
			services.AddDbContext<EcommerceDbContext>(options => 
				options.UseSqlServer(connectionString)
				.EnableSensitiveDataLogging());

			services.AddScoped<IProductsRepository, ProductsRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}
	}
}
