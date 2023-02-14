namespace Bakerbots.Models
{
    public class Order_Status
    {
        public int Id { get; set; }
        //public int Order_ID { get; set; }
        public string Order_Status_Description { get; set; }
        //public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public IEnumerable<Order> Orders { get; set; }

    }
}
