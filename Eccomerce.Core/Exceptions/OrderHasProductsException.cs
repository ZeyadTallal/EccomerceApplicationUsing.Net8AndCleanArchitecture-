namespace Ecommerce.Core.Exceptions
{
	public class OrderHasProductsException: Exception
	{
        public OrderHasProductsException(string orderId) : base($"Order with id {orderId} can't be deleted")
        {
            
        }
    }
}
