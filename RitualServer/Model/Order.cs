using System;
using System.Collections.Generic;

namespace RitualServer.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderService> OrderService { get; set; } = new List<OrderService>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public virtual ICollection<UsersOrder> UsersOrders { get; set; } = new List<UsersOrder>();

    public virtual StatusOrder? Status { get; set; }
}
