using System;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace eCommerce.Web.Infrastructure.Swagger;

public static class ServiceCollectionExtensions
{
    private const string SwaggerTitleFormat = "eCommerce API {0}";

    public static void AddSwagger(this IServiceCollection services)
    {
        services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
            .AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                foreach (var xmlPath in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
                {
                    options.IncludeXmlComments(xmlPath);
                }

                options.CustomSchemaIds(x => x.FullName);
            });
    }

    public static void UseSwagger(this IApplicationBuilder builder, IApiVersionDescriptionProvider provider)
    {
        builder
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        string.Format(SwaggerTitleFormat, description.ApiVersion));
                }
            });
    }
}