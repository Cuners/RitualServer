using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Participant
{
    public int Id { get; set; }

    public int? UsersId { get; set; }

    public int? ConservationId { get; set; }

    public int? TypeId { get; set; }

    public virtual Conservation? Conservation { get; set; }

    public virtual TypeParticipant? Type { get; set; }

    public virtual User? Users { get; set; }

    public virtual ICollection<UsersParticipant> UsersParticipants { get; set; } = new List<UsersParticipant>();
}
