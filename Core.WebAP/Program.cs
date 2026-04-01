using Core.Application.Features.Products.Queries;
using Core.Application.Interfaces;
using Core.Domain.Repositories;
using Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Infrastructure;
using Persistence.Infrastructure.Persistence;
using Presentacion.WebAP.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ======================
// CONTROLLERS
// ======================
builder.Services.AddControllers();

// ======================
// MEDIATR (CQRS)
// ======================
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetProductsQuery).Assembly);
});

// ======================
// INFRASTRUCTURE (DB)
// ======================
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=learning;Uid=root;Pwd=oracle;Port=3306";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// ======================
// REPOSITORIES
// ======================
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// ======================
// PIPELINE
// ======================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();