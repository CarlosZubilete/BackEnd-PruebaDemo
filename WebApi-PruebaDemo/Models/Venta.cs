using System;
using System.Collections.Generic;

namespace WebApi_PruebaDemo.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int Idcliente { get; set; }

    public DateTime? Fecha { get; set; }

    public double? Total { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual ICollection<Ventasitem> Ventasitems { get; set; } = new List<Ventasitem>();
}
