using Ecommerce.Core.IRepositories.IProduct;
using FluentValidation;

namespace Ecommerce.Application.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
	{
		private readonly IProductsRepository _productsRepository;
		public UpdateProductCommandValidator(IProductsRepository productsRepository)
        {
			_productsRepository = productsRepository;

			RuleFor(dto => dto.ProductName)
			.Must(IsNameUnique)
			.WithMessage("Product Name Must Be Unique!");
		}
		private bool IsNameUnique(string name)
		{
			var isExists = _productsRepository.IsNameExists(name);
			if (isExists)
				return false;

			return true;
		}
	}
}
