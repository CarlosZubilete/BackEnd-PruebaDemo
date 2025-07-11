using System;
using System.Collections.Generic;

namespace WebApi_PruebaDemo.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public double? Precio { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<Ventasitem> Ventasitems { get; set; } = new List<Ventasitem>();
}
