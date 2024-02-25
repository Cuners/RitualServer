using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
