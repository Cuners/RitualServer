using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class OrderService
{
    public int OrderServiceId { get; set; }

    public int? OrderId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Order OrderServiceNavigation { get; set; } = null!;

    public virtual Service? Service { get; set; }
}
