using Ecommerce.Application.Dto.Products;
using FluentValidation;

namespace Ecommerce.Application.Orders.Queries.GetAllOrders
{
	public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
	{
		private int[] allowedPagesSize = [5, 10, 15, 30];
        public GetAllOrdersQueryValidator()
        {
			RuleFor(r => r.PageNumber)
				.GreaterThanOrEqualTo(1);

			RuleFor(r => r.PageSize)
				.Must(x => allowedPagesSize.Contains(x))
				.WithMessage($"Page size must be in [{string.Join(",", allowedPagesSize)}]");
		}
    }

	
}
