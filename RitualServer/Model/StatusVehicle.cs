using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class StatusVehicle
{
    public int StatusVehicleId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
