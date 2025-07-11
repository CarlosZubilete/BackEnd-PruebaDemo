using System;
using System.Collections.Generic;

namespace WebApi_PruebaDemo.Models;

public partial class Producto
{
  public int Id { get; set; }

  public string Nombre { get; set; } = null!; // Null is not allower.

  public double? Precio { get; set; }

  public string? Categoria { get; set; }

  public bool Eliminado { get; set; } = false;
  public virtual ICollection<Ventasitem> Ventasitems { get; set; } = new List<Ventasitem>();
}
