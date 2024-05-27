using Ecommerce.Core.Constants;
using Ecommerce.Core.Entities.Orders;

namespace Ecommerce.Core.IRepositories.IOrder
{
	public interface IOrderRepository
	{
		Task<(IEnumerable<Order>, int)> GetAllAsync(string? Keyword, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
		Task<Order> GetByIdAsync(int id);
		Task<int> Create(Order order);
		bool IsNameExists(string name);
		Task Delete(Order order);
		Task SaveChanges();
	}
}
