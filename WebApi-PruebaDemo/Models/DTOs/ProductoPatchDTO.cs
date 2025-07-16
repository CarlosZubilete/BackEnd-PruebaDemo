namespace WebApi_PruebaDemo.Models.DTOs;

public class ProductoPatchDTO
{
  public string? Nombre { get; set; }
  public double? Precio { get; set; }
  public string? Categoria { get; set; }
}

// Maybe we can add a validator for this DTO in the future.
// Or we can declarete = not null for the properties that we want to be required.