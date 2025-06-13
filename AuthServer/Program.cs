using Duende.IdentityServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

builder.Services.AddIdentityServer(options =>
{
    options.Authentication.CookieSameSiteMode = SameSiteMode.Lax;
})
.AddInMemoryIdentityResources(AuthServer.Config.IdentityResources)
.AddInMemoryApiScopes(AuthServer.Config.ApiScopes)
.AddInMemoryClients(AuthServer.Config.Clients)
.AddTestUsers(AuthServer.Config.TestUsers)
.AddDeveloperSigningCredential();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapGet("/", () => "IdentityServer is running.");

app.Run();