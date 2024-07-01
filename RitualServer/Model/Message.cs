using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Message
{
    public int MessageId { get; set; }

    public string? Message1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? RazgovorId { get; set; }

    public int? SenderId { get; set; }


    public virtual Conservation? Razgovor { get; set; }

    public virtual User? Sender { get; set; }

    public virtual ICollection<VlozheniaMess> VlozheniaMesses { get; set; } = new List<VlozheniaMess>();
}
