using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.Entities.Products;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
	public class CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger,
		IProductsRepository productsRepository) : IRequestHandler<CreateProductCommand, int>
	{
		public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Creating a new Product");


			using var stream = request.ProductImage != null ? new MemoryStream() : null;
			
			if (stream != null)
			{
				await request.ProductImage.CopyToAsync(stream);
			}

			var product = new Product
			{

				ProductName = request.ProductName,
				ProductDescription = request.ProductDescription,
				Price = request.Price,
				Merchant = request.Merchant,
				ProductImage =stream != null ?  stream.ToArray() : null,
			};

			int id = await productsRepository.Create(product);
			return id;
		}
	}
}
