using AutoMapper;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger,
		IProductsRepository productsRepository,
		IMapper mapper) : IRequestHandler<UpdateProductCommand, bool>
	{
		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation("Updating Product with id : {ProductId} with {@UpdateProduct}" , request.Id , request);

			var product = await productsRepository.GetByIdAsync(request.Id);

			if (product is null)
				return false;

			//mapper.Map(request,product);
			using var stream = request.ProductImage != null ? new MemoryStream() : null;

			if (stream != null)
			{
				await request.ProductImage.CopyToAsync(stream);
			}

			product.ProductName = request.ProductName;
			product.ProductDescription = request.ProductDescription;
			product.Price = request.Price;
			product.Merchant = request.Merchant;
			product.ProductImage = stream != null ? stream.ToArray() : null;

			await productsRepository.SaveChanges();
			
			return true;
		}
	}
}
