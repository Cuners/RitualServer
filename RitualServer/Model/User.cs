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

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public int? RoleId { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Conservation> Conservations { get; set; } = new List<Conservation>();

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual Role UserNavigation { get; set; } = null!;

    public virtual ICollection<UsersParticipant> UsersParticipants { get; set; } = new List<UsersParticipant>();
}
