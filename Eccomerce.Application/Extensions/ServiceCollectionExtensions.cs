﻿using Ecommerce.Application.Services.ProductsServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

			services.AddScoped<IProductsService, ProductsService>();

			services.AddAutoMapper(applicationAssembly);

			services.AddValidatorsFromAssembly(applicationAssembly)
				.AddFluentValidationAutoValidation();
		}
	}
}