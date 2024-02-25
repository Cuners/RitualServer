using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class TypeParticipant
{
    public int TypeParticipantsId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
