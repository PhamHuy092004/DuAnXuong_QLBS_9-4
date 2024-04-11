using DA_Xuong.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "customer_layout",
    pattern: "Customer/{controller=Customer}/{action=Index}/{id?}",
    defaults: new { area = "Customer", controller = "Customer", action = "Index" }
);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=SACHes}/{action=Index}/{id?}");

app.Run();
