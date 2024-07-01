namespace RitualServer.Model
{
    public class UsersOrder
    {
        public int UsersOrderID { get; set; }

        public int? UserID { get; set; }

        public int? OrderID { get; set; }

        public virtual Order? Orders { get; set; }

        public virtual User? Users { get; set; }
    }
}
