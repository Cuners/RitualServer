using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Conservation
{
    public int ConservationId { get; set; }

    public string? Title { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? CreatorId { get; set; }

    public int? TypeId { get; set; }
    public virtual User? Creator { get; set; }
    public virtual TypeParticipant? Type { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();


    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
