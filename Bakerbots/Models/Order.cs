using System.ComponentModel.DataAnnotations;

namespace Bakerbots.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Order_StatusId { get; set; }
        public int User_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_ID { get; set; }

        [DataType(DataType.Date)]
        public string Order_Date { get; set;}
        public string Address { get; set;}
        public int Product_Quantity { get; set; }
        public int Total_Amount { get; set; }
        public Order_Status Status { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }

    }
}
