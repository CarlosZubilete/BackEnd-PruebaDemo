using WebApi_PruebaDemo.Models; // include the file Models.
using Microsoft.EntityFrameworkCore; // Include the library.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To add the connection string to the context of the Database.
builder.Services.AddDbContext<PruebademoContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
