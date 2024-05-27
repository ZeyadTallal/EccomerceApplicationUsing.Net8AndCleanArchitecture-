
using Ecommerce.Core.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Ecommerce.Api.Middlewares
{
	public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next.Invoke(context);
			}
			catch(NotFoundException notFound)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync(notFound.Message);

				logger.LogWarning(notFound.Message);
			}
			catch(OrderHasProductsException orderHasProducts)
			{
				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				await context.Response.WriteAsync(orderHasProducts.Message);

				logger.LogWarning(orderHasProducts.Message);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, ex.Message);

				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something went wrong");
			}
		}
	}
}
