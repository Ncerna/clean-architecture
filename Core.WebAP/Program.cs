using Presentacion.WebAP.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// Middleware de manejo de excepciones
app.UseMiddleware<ExceptionMiddleware>();

// Middleware habituales
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

