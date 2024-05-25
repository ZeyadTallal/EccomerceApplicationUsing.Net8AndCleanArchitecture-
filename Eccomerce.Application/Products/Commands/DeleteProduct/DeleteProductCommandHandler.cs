using Ecommerce.Core.Entities.Products;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.IRepositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
		IProductsRepository productsRepository) : IRequestHandler<DeleteProductCommand>
	{
		public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			logger.LogInformation($"Deleting Product with id : {request.Id}");
			
			var product = await productsRepository.GetByIdAsync(request.Id);

			if (product is null)
				throw new NotFoundException(nameof(Product),request.Id.ToString());

			await productsRepository.Delete(product);
		}
	}
}
