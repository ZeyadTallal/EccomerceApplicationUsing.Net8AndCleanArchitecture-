using Ecommerce.Application.Common;
using Ecommerce.Application.Dto.Products;
using Ecommerce.Core.Constants;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
	public class GetAllProductsQuery : IRequest<PagedResult<ProductDto>>
	{
        public string? Keyword { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string? SortBy { get; set; }
		public SortDirection SortDirection { get; set; }
    }
}
