using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? ShipmentDate { get; set; }

    public string? Address { get; set; }

    public virtual Order? Order { get; set; }
}
