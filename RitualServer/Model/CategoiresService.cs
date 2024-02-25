using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class CategoiresService
{
    public int CategoriesServicesId { get; set; }

    public string? Name { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
