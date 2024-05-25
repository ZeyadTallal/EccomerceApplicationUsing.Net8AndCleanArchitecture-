using Ecommerce.Application.Dto.Products;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Products.Commands.DeleteProduct;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Application.Products.Queries.GetAllProducts;
using Ecommerce.Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.Products
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	
	public class ProductsController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
		{
			var products = await mediator.Send(new GetAllProductsQuery());
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDto?>> GetById([FromRoute]int id)
		{
			var product = await mediator.Send(new GetProductByIdQuery(id));

			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]CreateProductCommand input)
		{
			int id = await mediator.Send(input);
			return CreatedAtAction(nameof(GetById), new { id } , null);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await mediator.Send(new DeleteProductCommand(id));

			
			return NoContent();
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id , UpdateProductDto input)
		{
			var updateProductCommand = new UpdateProductCommand()
			{
				Id = id,
				ProductName = input.ProductName,
				ProductDescription = input.ProductDescription,
				ProductImage = input.ProductImage,
				Price = input.Price,
				Merchant = input.Merchant,
			};

			await mediator.Send(updateProductCommand);//new UpdateProductCommand(id));

			return NoContent();
		}
	}
	
}
