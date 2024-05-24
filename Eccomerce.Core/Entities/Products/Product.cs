using Ecommerce.Core.Entities.OrderProducts;

namespace Ecommerce.Core.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; } = new byte[0];
        public decimal Price { get; set; }
        public string Merchant { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
