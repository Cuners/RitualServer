using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Color
{
    public int ColorId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Clothe> Clothes { get; set; } = new List<Clothe>();

    public virtual ICollection<Coffin> Coffins { get; set; } = new List<Coffin>();

    public virtual ICollection<Cross> Crosses { get; set; } = new List<Cross>();

    public virtual ICollection<Monument> Monuments { get; set; } = new List<Monument>();

    public virtual ICollection<Tape> Tapes { get; set; } = new List<Tape>();

    public virtual ICollection<Urn> Urns { get; set; } = new List<Urn>();
}
