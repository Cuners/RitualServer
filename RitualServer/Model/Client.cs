namespace RitualServer.Model
{
    public class Client
    {
        public int ClientId { get; set; }

        public string? FIO { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();
    }
}
