namespace Bakerbots.Models
{
    public class User
    {
        public int Id { get; set; }
        public string User_Name { get; set;}
        public string Role_ID { get; set; }
        public string User_Email { get; set;}
        public string User_Password { get; set;}
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();

    }
}
