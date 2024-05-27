using Ecommerce.Core.Constants;
using Ecommerce.Core.Entities.Orders;
using Ecommerce.Core.IRepositories.IOrder;
using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories.Orders
{
	public class OrderRepository(EcommerceDbContext dbContext) : IOrderRepository
	{
		public async Task<(IEnumerable<Order>, int)> GetAllAsync(string? Keyword, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
		{
			var searchByValue = Keyword?.ToLower();

			var query = dbContext.Orders
				.Include(x => x.OrderProducts)
				.ThenInclude(x=>x.Product)
				.Include(x => x.Customer)
				.Where(r => searchByValue == null ||
						(r.Customer.Name.ToLower().Contains(searchByValue) || r.DeliveryAdress.ToLower().Contains(searchByValue)));

			var totalCount = await query.CountAsync();

			var orders = await query
				.Skip(pageSize * (pageNumber - 1))
				.Take(pageSize)
				.ToListAsync();

			return (orders, totalCount);
		}
		public async Task<Order> GetByIdAsync(int id)
		{
			var order = await dbContext.Orders
				.Include(x=>x.OrderProducts)
				.ThenInclude(x => x.Product)
				.Include(x => x.Customer)
				.FirstOrDefaultAsync(x => x.Id == id);
			return order;
		}
		public async Task<int> Create(Order order)
		{
			dbContext.Orders.Add(order);
			await dbContext.SaveChangesAsync();
			return order.Id;
		}
		public async Task Delete(Order order)
		{
			dbContext.Remove(order);
			await dbContext.SaveChangesAsync();
		}
		public bool IsNameExists(string name)
		{
			throw new NotImplementedException();
		}
		public async Task SaveChanges() => await dbContext.SaveChangesAsync();
	}
}
