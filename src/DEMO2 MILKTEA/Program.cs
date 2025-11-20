using Microsoft.EntityFrameworkCore; // 1. Thư viện để kết nối SQL
using MILKTEASHOP.Models;        // 2. Namespace chứa TraSuaDbContext của bạn

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ==================================================================
// BẮT ĐẦU: Cấu hình kết nối Database (Thêm đoạn này)
// ==================================================================
builder.Services.AddDbContext<TraSuaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TraSuaContext")));
// ==================================================================
// KẾT THÚC
// ==================================================================

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();