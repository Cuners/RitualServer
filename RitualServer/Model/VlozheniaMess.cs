using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class VlozheniaMess
{
    public int VlozheniaMessId { get; set; }

    public string? ThumbUrl { get; set; }

    public string? FileUrl { get; set; }

    public int? MessageId { get; set; }

    public virtual Message? Message { get; set; }
}
