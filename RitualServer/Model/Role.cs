using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Role
{
    public int RolesId { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();


}
