using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ecommerce.Api.SwaggerVersioning
{
	public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
			_provider = provider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
		{
			foreach(ApiVersionDescription description in _provider.ApiVersionDescriptions)
			{
				var openApiInfo = new OpenApiInfo
				{
					Title = $"Ecommerce.Api v{description.ApiVersion}",
					Version = description.ApiVersion.ToString(),
				};

				options.SwaggerDoc(description.GroupName , openApiInfo);
			}
		}

		public void Configure(SwaggerGenOptions options)
		{
			Configure(options);
		}
	}
}
