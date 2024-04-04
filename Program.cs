using Microsoft.EntityFrameworkCore;
using static SQLEFTask.Services;

namespace SQLEFTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.Migrate();

                while (true)
                {
                    Console.WriteLine("Enter begin date (example: 01.01.2023)");
                    string beginDate = Console.ReadLine();

                    DateTime parsedBeginDate;
                    if (!DateTime.TryParse(beginDate, out parsedBeginDate))
                    {
                        throw new ArgumentException("Invalid input format for date. Please enter date in the correct format (dd.MM.yyyy)");
                    }

                    Console.WriteLine("Enter amount of all order (example: 10000)");
                    string sumAmount = Console.ReadLine();

                    int parsedSumAmount;
                    if (!int.TryParse(sumAmount, out parsedSumAmount))
                    {
                        throw new ArgumentException("Invalid input format for amount. Please enter a valid integer");
                    }

                    CustomerServices service = new Services.CustomerServices();
                    var customers = service.GetCustomers(context, Convert.ToDateTime(beginDate), Convert.ToInt32(sumAmount));


                    Console.WriteLine("CustomerName|ManagerName|Amount");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"{customer.CustomerName.PadRight(11)} | {customer.ManagerName.PadRight(9)} | {customer.Amount}");
                        Console.WriteLine(new string('-', 33));
                    }
                }
            }
        }
    }
}
