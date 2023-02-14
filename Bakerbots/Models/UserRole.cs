namespace Bakerbots.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string UserRole_Name { get; set; }
        public virtual ICollection<User> Users { get; } = new List<User>();

    }
}
