using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? SurName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public int? RoleId { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Conservation> Conservations { get; set; } = new List<Conservation>();

    public virtual ICollection<UsersOrder> UsersOrders { get; set; } = new List<UsersOrder>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual Role? Roles { get; set; }

}
