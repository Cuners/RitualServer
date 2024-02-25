using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int? BrandId { get; set; }

    public int? ModelId { get; set; }

    public string? FuneralEquipment { get; set; }

    public int? Quantity { get; set; }

    public byte[]? Image { get; set; }

    public int? StatusId { get; set; }

    public int? ServicesId { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public DateTime? NextMaintenanceDate { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Model? Model { get; set; }

    public virtual Service? Services { get; set; }

    public virtual StatusVehicle? Status { get; set; }
}
