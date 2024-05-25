using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.IRepositories.IProduct;
using FluentValidation;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateProductCommandValidator(IProductsRepository productsRepository)
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
