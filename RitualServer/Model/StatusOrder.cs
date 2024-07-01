namespace RitualServer.Model
{
    public class StatusOrder
    {
        public int StatusOrderId { get; set; }

        public string? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
