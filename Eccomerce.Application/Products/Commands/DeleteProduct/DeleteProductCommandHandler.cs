using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
		IProductsRepository productsRepository) : IRequestHandler<DeleteProductCommand , bool>
	{
		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation($"Deleting Product with id : {request.Id}");
			
			var product = await productsRepository.GetByIdAsync(request.Id);

			if (product is null)
				return false;

			await productsRepository.Delete(product);
			return true;
		}
	}
}
