using AutoMapper;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Core.Entities.Products;

namespace Ecommerce.Application.Dto.Products
{
	public class ProductsProfile : Profile
	{
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
            //CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
