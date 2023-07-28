using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Aseguradora.UI.Data;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//agrego mis servicios al contenedor
//titular
builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddTransient<ObtenerTitularUseCase>();
builder.Services.AddTransient<ListarTitularesConSusVehiculosUseCase>();

//vehiculo
builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddTransient<ObtenerVehiculoUseCase>();

//poliza
builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddTransient<ObtenerPolizaUseCase>();
builder.Services.AddTransient<ObtenerPolizaDesdeVehiculoUseCase>();

//siniestro
builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();
builder.Services.AddTransient<ObtenerSiniestroUseCase>();

//tercero
builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();
builder.Services.AddTransient<ObtenerTerceroUseCase>();

//repositorios
builder.Services.AddScoped<AseguradoraContext>();
builder.Services.AddScoped<IRepositorioTitular,RepositorioTitular>();
builder.Services.AddScoped<IRepositorioVehiculo,RepositorioVehiculo>();
builder.Services.AddScoped<IRepositorioPoliza,RepositorioPoliza>();
builder.Services.AddScoped<IRepositorioSiniestro,RepositorioSiniestro>();
builder.Services.AddScoped<IRepositorioTercero,RepositorioTercero>();

Inicializador.Ejecutar(); //ejecuta database.ensurecreated y crea 3 titulares

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
