using Business.DataAccess.Contexts;
using Business.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using static Business.DataAccess.Services.StoreServiceBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region IoC (Inversion of Control)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

// AddScoped: istek (request) boyunca objenin referansını (genelde interface veya abstract class)
// kullandığımız yerde obje (somut class'tan oluşuturulacak) bir kere oluşturulur ve
// yanıt (response) dönene kadar bu obje hayatta kalır.
// AddSingleton: web uygulaması başladığında objenin referansını (genelde interface veya abstract class)
// kullandığımız yerde obje (somut class'tan oluşturulacak) bir kere oluşturulur ve uygulama çalıştığı
// (IIS üzerinden uygulama durdurulmadığı veya yeniden başlatılmadığı) sürece bu obje hayatta kalır.
// AddTransient: istek (request) bağımsız ihtiyaç olan objenin referansını (genelde interface veya abstract class)
// kullandığımız her yerde bu objeyi new'ler.
// Genelde AddScoped methodu kullanılır.
builder.Services.AddScoped<ProductServiceBase, ProductService>();
builder.Services.AddScoped<CategoryServiceBase, CategoryService>();
builder.Services.AddScoped<StoreServiceBase, StoreService>();
//TODO
#endregion

builder.Services.AddControllersWithViews();

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
