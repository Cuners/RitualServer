using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Cross
{
    public int CrossId { get; set; }

    public int? ColorId { get; set; }

    public int? MaterialId { get; set; }

    public byte[]? Image { get; set; }

    public int? ProductId { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Material? Material { get; set; }

    public virtual Product? Product { get; set; }
}
