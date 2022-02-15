using eCommerce.Authentication.Web.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddClientStore<ClientStore>()
    .AddResourceStore<ResourceStore>();

builder.Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(_ =>
        {
            _.AllowAnyOrigin();
            _.AllowAnyHeader();
            _.AllowAnyMethod();
        });
    })
    .AddRouting(options =>
    {
        options.LowercaseUrls = true;
    });

builder.Services
    .AddControllersWithViews();

var app = builder.Build();

app.UseCors();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
