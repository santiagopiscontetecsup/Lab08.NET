using System.Text.Json.Serialization;
using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Persistence;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Lab08_SantiagoPisconteChuctaya.Persistence.Queries;
using Lab08_SantiagoPisconteChuctaya.Persistence.Repositories;
using Lab08_SantiagoPisconteChuctaya.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Configurar para manejar ciclos
    });

// Add services to the container.
builder.Services.AddControllers();

// Agregar la configuración de MySQL para el contexto de la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LINQPisconteContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Agregar Swagger con configuración personalizada (como en tu código anterior)
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryGeneric<Client>, RepositoryGeneric<Client>>();
builder.Services.AddScoped<IRepositoryGeneric<Product>, RepositoryGeneric<Product>>();
builder.Services.AddScoped<IRepositoryGeneric<Order>, RepositoryGeneric<Order>>();
builder.Services.AddScoped<IRepositoryGeneric<Orderdetail>, RepositoryGeneric<Orderdetail>>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILab09Service, Lab09Service>();

builder.Services.AddScoped<ClientsOrdersQuery>();
builder.Services.AddScoped<OrdersDetailsQuery>();
builder.Services.AddScoped<ClientsProductsSummaryQuery>();
builder.Services.AddScoped<SalesByClientQuery>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Middleware para mostrar Swagger (sólo en desarrollo si quieres)
if (app.Environment.IsDevelopment())
{
    // JSON endpoint de Swagger
    app.UseSwagger();

    // Interfaz de usuario de Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();