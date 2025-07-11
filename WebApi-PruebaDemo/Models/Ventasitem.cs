using System;
using System.Collections.Generic;

namespace WebApi_PruebaDemo.Models;

public partial class Ventasitem
{
    public int Id { get; set; }

    public int Idventa { get; set; }

    public int Idproducto { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? Cantidad { get; set; }

    public double? PrecioTotal { get; set; }

    public virtual Producto IdproductoNavigation { get; set; } = null!;

    public virtual Venta IdventaNavigation { get; set; } = null!;
}
