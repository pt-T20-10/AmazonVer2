using Microsoft.EntityFrameworkCore;
using AmazonWebsite.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using AmazonWebsite.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AmazonContext>((provider, options) => {
    IConfiguration config = provider.GetRequiredService<IConfiguration>();
    string connectionString = config.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//https://docs.automapper.org/en/stable/Dependency-injection.html
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie (options =>
{
    options.LoginPath ="/Customer/Login ";
    options.AccessDeniedPath = "/AccessDenied";
});
                                                                                                 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Route cho Areas
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=AdminProduct}/{action=Index}/{id?}"
    );
    // Route mặc định
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=CustomerHome}/{action=Index}/{id?}"
    );
});

app.Run();
