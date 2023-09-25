using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Common.Infrastructure;
using Common.Models;

var builder = WebApplication.CreateBuilder(args);
 

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromSeconds(2)
    //options.IdleTimeout = TimeSpan.FromDayss(2)
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CmsShoppingCartContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("CmsShoppingCartContext")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<CmsShoppingCartContext>
    ().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch(Exception)
    {
        throw;
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
      name: "Areas",
      pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}"
       );
app.MapControllerRoute(
      name: "Default",
      pattern: "{controller=Products}/{action=Index}/{id?}"
       );
/*app.MapControllerRoute(
    name: "pages",
          "{slug?}",
    defaults: new { controller = "Pages", action = "Page" }
    );*/

app.MapControllerRoute(
                      "products",
                   
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
       );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
