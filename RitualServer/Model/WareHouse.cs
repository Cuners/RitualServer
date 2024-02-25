using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class WareHouse
{
    public int CompositionId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
