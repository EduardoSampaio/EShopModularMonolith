

using System.Reflection;
using Carter;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
       .AddCatalogModule(builder.Configuration)
       .AddBasketModule(builder.Configuration)
       .AddOrderingModule(builder.Configuration);

// Add services to the container.
var catalogAssembly = typeof(CatalogModule).Assembly;
var basketAssembly = typeof(BasketModule).Assembly;
var orderingAssembly = typeof(OrderingModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(catalogAssembly, basketAssembly, orderingAssembly);

builder.Services
    .AddMediatRWithAssemblies(catalogAssembly, basketAssembly, orderingAssembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
//module services: catalog, basket, ordering


app.UseHttpsRedirection();
app.MapCarter();
app.UseCatalogModule()
   .UseBasketModule()
   .UseOrderingModule();

app.Run();
