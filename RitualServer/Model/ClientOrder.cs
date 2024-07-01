namespace RitualServer.Model
{
    public class ClientOrder
    {
        public int ClientOrdersID { get; set; }

        public int? ClientID { get; set; }

        public int? OrderID { get; set; }
      

        public virtual Order? Orders { get; set; }

        public virtual Client? Clients { get; set; }
    }
}
