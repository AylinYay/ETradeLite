using Business.DataAccess.Contexts;
using Business.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region IoC (Inversion of Control)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

// AddScoped: istek (request) boyunca objenin referans�n� (genelde interface veya abstract class)
// kulland���m�z yerde obje (somut class'tan olu�uturulacak) bir kere olu�turulur ve
// yan�t (response) d�nene kadar bu obje hayatta kal�r.
// AddSingleton: web uygulamas� ba�lad���nda objenin referans�n� (genelde interface veya abstract class)
// kulland���m�z yerde obje (somut class'tan olu�turulacak) bir kere olu�turulur ve uygulama �al��t���
// (IIS �zerinden uygulama durdurulmad��� veya yeniden ba�lat�lmad���) s�rece bu obje hayatta kal�r.
// AddTransient: istek (request) ba��ms�z ihtiya� olan objenin referans�n� (genelde interface veya abstract class)
// kulland���m�z her yerde bu objeyi new'ler.
// Genelde AddScoped methodu kullan�l�r.
builder.Services.AddScoped<ProductServiceBase, ProductService>();
builder.Services.AddScoped<CategoryServiceBase, CategoryService>();
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