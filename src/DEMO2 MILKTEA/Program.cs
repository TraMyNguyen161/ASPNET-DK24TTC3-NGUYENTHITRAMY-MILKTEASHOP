using Microsoft.EntityFrameworkCore; // 1. Thư viện để kết nối SQL
using MILKTEASHOP.Models;        // 2. Namespace chứa TraSuaDbContext của bạn

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Session & cache must be registered before Build()
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ==================================================================
// BẮT ĐẦU: Cấu hình kết nối Database
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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session middleware must be added to the pipeline before endpoints
app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();