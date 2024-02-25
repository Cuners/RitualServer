using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class SizeCoffin
{
    public int SizeCoffinsId { get; set; }

    public int? SizeCofId { get; set; }

    public int? CoffinId { get; set; }

    public virtual Coffin? Coffin { get; set; }

    public virtual SizesCof? SizeCof { get; set; }
}
