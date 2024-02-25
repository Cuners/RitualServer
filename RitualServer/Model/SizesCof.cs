using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class SizesCof
{
    public int SizeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SizeCoffin> SizeCoffins { get; set; } = new List<SizeCoffin>();
}
