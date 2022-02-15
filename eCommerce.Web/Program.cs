using System.Text.Json;
using System.Text.Json.Serialization;

using eCommerce.Application.Infrastructure;
using eCommerce.Payments.WayForPay;
using eCommerce.Persistence.Mongo;
using eCommerce.Web.Infrastructure.Attributes;
using eCommerce.Web.Infrastructure.Errors;
using eCommerce.Web.Infrastructure.Swagger;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<GlobalExceptionFilterAttribute>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

services
    .AddRouting(options =>
    {
        options.LowercaseUrls = true;
    });

services
    .AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = ApiVersion.Default;
    })
    .AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    })
    .AddSwagger();

services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7047/";
        options.Audience = "ecommerce";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "name"
        };
    });

services.AddWayForPayClient();
services.AddApplication();
services.AddPersistence();

services.AddSingleton<WebApiErrorProvider>();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapControllers();
});

//app.UseStaticFiles();
app.UseSwagger(apiVersionDescriptionProvider);
//app.MapFallbackToFile("index.html");
app.Run();
