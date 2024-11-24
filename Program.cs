using efapp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddDbContext<EFAppContext>(options => options.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<EFAppContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] EFAppContext context) => {
    context.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ context.Database.IsInMemory());
});

app.Run();
