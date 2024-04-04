using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLEFTask
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Manager Manager { get; set; }
        public int ManagerID { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Manager
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Order
    {
        public int ID { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "real")]
        public double Amount { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerID { get; set; }
    }
    public class CustomerViewModel
    {
        public string CustomerName { get; set; }
        public string ManagerName { get; set; }
        public double Amount { get; set; }
    }

}
