using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;
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
    .GetValue<string>("ConnectionStrings:InnovaLocalDb");

builder.Services.AddDbContext<InnovaDbContext>(
    // Connect to SqlServer
    (config) => config.UseSqlServer(
        connStr, b => b.MigrationsAssembly("InnovaSystem"))
);

string webFront = builder.Configuration.GetValue<string>("CORS:web");
string webFront2 = builder.Configuration.GetValue<string>("CORS:web2");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IRolService, RolServiceDbImpl>();
builder.Services.AddScoped<IRolRepository, RolRepositoryImpl>();

builder.Services.AddScoped<ITrabajadorService, TrabajadorServiceDbImpl>();
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepositoryImpl>();

builder.Services.AddScoped<IProveedorService, ProveedorServiceDbImpl>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepositoryImpl>();

builder.Services.AddScoped<IOrdenServicioTecnicoService, OrdenServicioTecnicoServiceDbImpl>();
builder.Services.AddScoped<IOrdenServicioTecnicoRepository, OrdenServicioTecnicoRepositoryImpl>();

builder.Services.AddScoped<IClienteService, ClienteServiceDbImpl>();
builder.Services.AddScoped<IClienteRepository, ClienteRepositoryImpl>();

builder.Services.AddScoped<IMarcaService, MarcaServiceDbImpl>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepositoryImpl>();

builder.Services.AddScoped<ICategoriaService, CategoriaServiceDbImpl>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepositoryImpl>();

builder.Services.AddScoped<IProductoService, ProductoServiceDbImpl>();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryImpl>();
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();  

app.UseRouting();

app.UseAuthorization();
        
app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();