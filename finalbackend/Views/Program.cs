using AlmacenMvc.Data;
using AlmacenMvc.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Habilitar MVC (controladores + vistas)
builder.Services.AddControllersWithViews();

// DbContext con SQL Server y cadena de conexión desde appsettings.json
builder.Services.AddDbContext<AlmacenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencia del repositorio
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Manejo de errores en producción
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto: Articulos/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articulos}/{action=Index}/{id?}");

app.Run();
