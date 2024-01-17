using NuGet.Protocol.Core.Types;
using CompanyWeb.Data;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CompanyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyDb"));
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(60);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
//app.UseMvcWithDefaultRoute();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Admin",
//    pattern: "{area:exists}/{controller=AdHome}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Login",
    pattern: "{area:exists}/{controller=Login}/{action=Index}");

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller}/{action}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();