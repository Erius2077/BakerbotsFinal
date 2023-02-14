namespace Bakerbots.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Price { get; set;}
        public string Product_Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }

    }

