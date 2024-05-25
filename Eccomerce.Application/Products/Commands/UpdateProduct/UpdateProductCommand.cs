using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Products.Commands.UpdateProduct
{
	public class UpdateProductCommand: IRequest
	{
		//[JsonIgnore]
		public int Id { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 1)]
		public string ProductName { get; set; }

		[Required]
		public string ProductDescription { get; set; }
		public IFormFile? ProductImage { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		public string Merchant { get; set; }
	}
}
