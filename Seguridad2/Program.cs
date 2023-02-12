using Seguridad2.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Agregamos los servicios del contenedor
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inyecci�n de Dependencias
builder.Services.AddApplicationServices(configuration);

//Se agrega la implementaci�n de los cors
builder.Services.AddCors();

//Establecemos el tipo de autenticaci�n
builder.Services.AddIdentityServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Metodo de Extensi�n: Pueden hacer varias operaciones al mismo tiempo
/*
 * Ventajas: El codigo es mas peque�o
 * Desventaja: Utilizan clases estaticas
 */