

var builder = WebApplication.CreateBuilder(args);
builder.Services
       .AddCatalogModule(builder.Configuration)
       .AddBasketModule(builder.Configuration)
       .AddOrderingModule(builder.Configuration);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
//module services: catalog, basket, ordering


app.UseHttpsRedirection();

app.UseCatalogModule()
   .UseBasketModule()
   .UseOrderingModule();

app.Run();
