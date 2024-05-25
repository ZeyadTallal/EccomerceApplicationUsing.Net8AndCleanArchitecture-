using Ecommerce.Application.Dto.Products;
using FluentValidation;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
	{
		private int[] allowedPagesSize = [5, 10, 15, 30];
        private string[] allowedSortByColumnNames = [nameof(ProductDto.ProductName),
        nameof(ProductDto.Price)];

        public GetAllProductsQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(r => r.PageSize)
                .Must(x => allowedPagesSize.Contains(x))
                .WithMessage($"Page size must be in [{string.Join(",", allowedPagesSize)}]");

            RuleFor(r => r.SortBy)
                .Must(x => allowedSortByColumnNames.Contains(x))
                .When(q => q.SortBy != null)
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
