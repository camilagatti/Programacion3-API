using Programacion3.API.Data;
using Programacion3.API.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuramos soporte para Controllers
builder.Services.AddControllers();

// 2. Registro de Inyeccion de Dependencias con ciclo de vida Scoped
// Se crea una instancia nueva por cada peticion HTTP recibida
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// 3. Configuracion de Swagger para documentar y probar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear las rutas de nuestros Controllers
app.MapControllers();

app.Run();
