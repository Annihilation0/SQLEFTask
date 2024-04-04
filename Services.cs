using Microsoft.EntityFrameworkCore;

namespace SQLEFTask
{
    public class Services
    {
        public class CustomerServices
        {
            public List<CustomerViewModel> GetCustomers(DatabaseContext context, DateTime beginDate, int sumAmount)
            {
                var customersWithTotalAmount = context.Orders
                .Where(o => o.Date >= beginDate)
                .GroupBy(o => o.CustomerID)
                .Select(g => new
                {
                    CustomerID = g.Key,
                    TotalAmount = g.Sum(o => o.Amount)
                })
                .Where(total => total.TotalAmount > sumAmount)
                .Join(context.Customers, total => total.CustomerID, c => c.ID, (total, c) => new CustomerViewModel
                {
                    CustomerName = c.Name,
                    ManagerName = c.Manager.Name,
                    Amount = total.TotalAmount
                })
                .ToList();

                return customersWithTotalAmount;
            }
        }
    }
}
