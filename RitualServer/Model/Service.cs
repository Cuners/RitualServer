using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Service
{
    public int ServicesId { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Opisanie { get; set; }

    public int? CategoryId { get; set; }

    public byte[]? Image { get; set; }

    public virtual CategoiresService? Category { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
