using WebApi_PruebaDemo.Models; // include the file Models.
using Microsoft.EntityFrameworkCore; // Include the library.
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions; // Include the library for FluentValidation.


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validation of ProductValidation.
builder.Services.AddValidatorsFromAssemblyContaining<Producto>(); // Register validators from the assembly containing the Producto class.
builder.Services.AddFluentValidationAutoValidation(); // aply automatic validation to the controllers.



// To add the connection string to the context of the Database.
builder.Services.AddDbContext<PruebademoContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQL"));
});

// Create a CORS policy to allow requests from the specified origin.
builder.Services.AddCors(options =>
{
  options.AddPolicy("NewPolicy", app =>
  {
    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("NewPolicy"); // Use the CORS Middlware.

app.UseAuthorization();

app.MapControllers();

app.Run();
