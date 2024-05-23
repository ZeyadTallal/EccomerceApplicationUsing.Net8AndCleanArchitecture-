using Ecommerce.Core.Entities.OrderProducts;

namespace Ecommerce.Core.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty ;
        public byte[] ProductImage { get; set; }
        public decimal Price { get; set; }
        public string Merchant { get; set; } = string.Empty;
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
