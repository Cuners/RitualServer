using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class TypeParticipant
{
    public int TypeParticipantsId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Conservation> Conservations { get; set; } = new List<Conservation>();
}
