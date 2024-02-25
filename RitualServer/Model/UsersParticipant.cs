using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class UsersParticipant
{
    public int Id { get; set; }

    public int? ParticipantId { get; set; }

    public int? UserId { get; set; }

    public virtual Participant? Participant { get; set; }

    public virtual User? User { get; set; }
}
