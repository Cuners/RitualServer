using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Participant
{
    public int Id { get; set; }

    public int? UsersId { get; set; }

    public int? ConservationId { get; set; }
    public bool? IsPinned { get; set; }

    public bool? IsArchived { get; set; }

    public virtual Conservation? Conservation { get; set; }

    public virtual User? Users { get; set; }

}
