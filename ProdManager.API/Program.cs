using Microsoft.EntityFrameworkCore;
using ProdManager.Application.Interfaces;
using ProdManager.Application.Services;
using ProdManager.Domain.Interfaces;
using ProdManager.Infrastructure;
using ProdManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("ProductsMemoryDb"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();