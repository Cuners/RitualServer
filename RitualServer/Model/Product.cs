using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public double Price { get; set; }

    public string? Opisanie { get; set; }

    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Clothe> Clothes { get; set; } = new List<Clothe>();

    public virtual ICollection<Coffin> Coffins { get; set; } = new List<Coffin>();

    public virtual ICollection<Cross> Crosses { get; set; } = new List<Cross>();

    public virtual ICollection<Monument> Monuments { get; set; } = new List<Monument>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Tape> Tapes { get; set; } = new List<Tape>();

    public virtual ICollection<Urn> Urns { get; set; } = new List<Urn>();

    public virtual ICollection<WareHouse> WareHouses { get; set; } = new List<WareHouse>();
}
