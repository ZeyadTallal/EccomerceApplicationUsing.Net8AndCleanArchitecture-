using Ecommerce.Application.Dto.Products;
using Ecommerce.Application.Services.ProductsServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.Products
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	
	public class ProductsController(IProductsService productsService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await productsService.GetAllProducts();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await productsService.GetProductById(id);

			if(product == null) 
				return NotFound();

			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]CreateProductDto input)
		{
			int id = await productsService.CreateProduct(input);
			return CreatedAtAction(nameof(GetById), new { id } , null);
		}
	}
	
}
