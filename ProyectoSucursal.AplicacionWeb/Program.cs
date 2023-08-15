using Microsoft.EntityFrameworkCore;
using ProyectoSucursal.BLL.Service;
using ProyectoSucursal.DAL.DataContext;
using ProyectoSucursal.DAL.Repositories;
using ProyectoSucursal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SucursalContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<Sucursal>, SucursalRepository>();
builder.Services.AddScoped<ISucursalService, SucursalService>();

builder.Services.AddScoped<IGenericRepository<Tecnico>, TecnicoRepository>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();

builder.Services.AddScoped<IGenericRepository<Elemento>, ElementoRepository>();
builder.Services.AddScoped<IElementoService, ElementoService>();

builder.Services.AddScoped<IGenericRepository<Asignacion>, AsignacionRepository>();
builder.Services.AddScoped<IAsignacionService, AsignacionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
