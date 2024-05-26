using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Ecommerce.Api.Middlewares;
using Ecommerce.Api.SwaggerVersioning;
using Ecommerce.Application.Extensions;
using Ecommerce.Infrastructure.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(option =>
{
	option.AssumeDefaultVersionWhenUnspecified = true;
	option.DefaultApiVersion = ApiVersion.Default;
	option.ReportApiVersions = true;
}).AddApiExplorer(option =>
{
	option.GroupNameFormat = "'v'V";
	option.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, configuration) => 
	configuration.ReadFrom.Configuration(context.Configuration)
	//.MinimumLevel.Override("Microsoft" , LogEventLevel.Warning)
	//.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
	//.WriteTo.File("Logs/Ecommerce-API-.log",rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
	//.WriteTo.Console(outputTemplate : "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine} {Message:lj}{NewLine}{Exception}")
);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		var descriptions = app.DescribeApiVersions();

		foreach(ApiVersionDescription description in descriptions)
		{
			string url = $"/swagger/{description.GroupName}/Swagger.json";
			string name = description.GroupName.ToUpperInvariant();

			options.SwaggerEndpoint(url, name);
		}
	});
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
