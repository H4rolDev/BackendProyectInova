using InnovaSystemBussines.Auth.repositories;
using InnovaSystemBussines.Auth.services;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Auth.repositories;
using InnovaSystemData.Auth.services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Store.Repositories;
using InnovaSystemData.Store.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connStr = builder.Configuration
    .GetValue<string>("ConnectionStrings:InnovaDocker");

builder.Services.AddDbContext<InnovaSystemData.Sources.DataBase.InnovaDbContext>(
    // Connect to SqlServer
    (config) => config.UseSqlServer(
        connStr, b => b.MigrationsAssembly("InnovaSystem"))
);

string web = builder.Configuration.GetValue<string>("CORS:web");
string web2 = builder.Configuration.GetValue<string>("CORS:web2");

builder.Services.AddCors(
    (conf) => conf.AddDefaultPolicy( policy => 
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            // .AllowAnyOrigin()
            // .WithMethods()
            .WithOrigins(web, web2)
    )
);

builder.Services.AddScoped<IRolService, RolServiceDbImpl>();
builder.Services.AddScoped<IRolRepository, RolRepositoryImpl>();

builder.Services.AddScoped<ITrabajadorService, TrabajadorServiceDbImpl>();
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepositoryImpl>();

builder.Services.AddScoped<IOrdenServicioTecnicoService, OrdenServicioTecnicoServiceDbImpl>();
builder.Services.AddScoped<IOrdenServicioTecnicoRepository, OrdenServicioTecnicoRepositoryImpl>();

builder.Services.AddScoped<IClienteService, ClienteServiceDbImpl>();
builder.Services.AddScoped<IClienteRepository, ClienteRepositoryImpl>();

builder.Services.AddScoped<IClienteDireccionService, ClienteDireccionServiceDbImpl>();
builder.Services.AddScoped<IClienteDireccionRepository, ClienteDireccionRepositoryImpl>();

builder.Services.AddScoped<IMarcaService, MarcaServiceDbImpl>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepositoryImpl>();

builder.Services.AddScoped<ICategoriaService, CategoriaServiceDbImpl>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepositoryImpl>();

builder.Services.AddScoped<IProductoService, ProductoServiceDbImpl>();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryImpl>();

builder.Services.AddScoped<ICargoService, CargoServiceDbImpl>();

builder.Services.AddScoped<IDetalleVentaService, DetalleVentaServiceDbImpl>();
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepositoryImpl>();

builder.Services.AddScoped<IDeliveryService, DeliveryServiceDbImpl>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepositoryImpl>();

builder.Services.AddScoped<IUsuarioService, UsuarioServiceDbImpl>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImpl>();

builder.Services.AddScoped<IVentaService, VentaServiceDbImpl>();
builder.Services.AddScoped<IVentaRepository, VentaRepositoryImpl>();

builder.Services.AddScoped<ITipoPagoService, TipoPagoServiceDbImpl>();
builder.Services.AddScoped<ITipoPagoRepository, TipoPagoRepositoryImpl>();

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepositoryImpl>();
builder.Services.AddScoped<IAuthenticationService, AuthenticactionServiceDbImpl>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();  

app.UseRouting();

app.UseAuthorization();
        
app.MapControllers();

app.UseCors();

app.Run();