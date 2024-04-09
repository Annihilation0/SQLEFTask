using Microsoft.EntityFrameworkCore;

namespace SQLEFTask
{
    public class Services
    {
        public class CustomerServices
        {
            public List<CustomerViewModel> GetCustomers(DatabaseContext context, DateTime beginDate, int sumAmount)
            {
                var customersWithTotalAmount = context.Customers
                    .Select(c => new CustomerViewModel
                    {
                        CustomerName = c.Name,
                        ManagerName = c.Manager.Name,
                        Amount = c.Orders
                        .Where(o => o.Date >= beginDate)
                        .Sum(o => o.Amount)
                    })
                    .Where(o => o.Amount > sumAmount).ToList();

                return customersWithTotalAmount;
            }
        }
    }
}
