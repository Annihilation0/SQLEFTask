using Microsoft.EntityFrameworkCore;

namespace SQLEFTask
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Orders.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasKey(m => m.ID);
            modelBuilder.Entity<Customer>().HasKey(c => c.ID);
            modelBuilder.Entity<Order>().HasKey(o => o.ID);


            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Manager)
                .WithMany()
                .HasForeignKey(c => c.ManagerID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerID);

            SeedData(modelBuilder);
        }
  
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager { ID = 1, Name = "John" },
                new Manager { ID = 2, Name = "Sarah" }
            );
            modelBuilder.Entity<Customer>().HasData(
                        new Customer { ID = 1, Name = "Alice", ManagerID = 1 },
                        new Customer { ID = 2, Name = "David", ManagerID = 2 },
                        new Customer { ID = 3, Name = "Jessica", ManagerID = 2 },
                        new Customer { ID = 4, Name = "Amanda", ManagerID = 1 }
        );
            modelBuilder.Entity<Order>().HasData(
            new Order { ID = 1, Date = new DateTime(2023, 6, 10), Amount = 1000.00, CustomerID = 1 },
                         new Order { ID = 2, Date = new DateTime(2023, 1, 10), Amount = 6400.00, CustomerID = 2 },
                         new Order { ID = 3, Date = new DateTime(2023, 2, 10), Amount = 5000.00, CustomerID = 3 },
                         new Order { ID = 4, Date = new DateTime(2023, 2, 10), Amount = 1000.00, CustomerID = 4 },
                         new Order { ID = 5, Date = new DateTime(2023, 3, 10), Amount = 500.00, CustomerID = 1 },
                         new Order { ID = 6, Date = new DateTime(2023, 4, 10), Amount = 1500.00, CustomerID = 2 },
                         new Order { ID = 7, Date = new DateTime(2023, 6, 10), Amount = 1500.00, CustomerID = 3 },
                         new Order { ID = 8, Date = new DateTime(2023, 5, 10), Amount = 1000.00, CustomerID = 4 },
                         new Order { ID = 9, Date = new DateTime(2023, 7, 10), Amount = 1500.00, CustomerID = 1 },
                         new Order { ID = 10, Date = new DateTime(2023, 12, 10), Amount = 5000.00, CustomerID = 2 },
                         new Order { ID = 11, Date = new DateTime(2022, 11, 10), Amount = 5500.00, CustomerID = 3 },
                         new Order { ID = 12, Date = new DateTime(2023, 10, 10), Amount = 500.00, CustomerID = 4 },
                         new Order { ID = 13, Date = new DateTime(2022, 3, 10), Amount = 1500.00, CustomerID = 1 },
                         new Order { ID = 14, Date = new DateTime(2023, 2, 10), Amount = 1500.00, CustomerID = 2 },
                         new Order { ID = 15, Date = new DateTime(2023, 5, 10), Amount = 5000.00, CustomerID = 3 },
                         new Order { ID = 16, Date = new DateTime(2023, 6, 10), Amount = 1500.00, CustomerID = 4 },
                         new Order { ID = 17, Date = new DateTime(2022, 11, 10), Amount = 1500.00, CustomerID = 1 },
                         new Order { ID = 18, Date = new DateTime(2022, 12, 10), Amount = 1050.00, CustomerID = 2 },
                         new Order { ID = 19, Date = new DateTime(2022, 7, 10), Amount = 2500.00, CustomerID = 3 },
                         new Order { ID = 20, Date = new DateTime(2022, 4, 10), Amount = 3000.00, CustomerID = 4 },
                         new Order { ID = 21, Date = new DateTime(2022, 8, 10), Amount = 2500.00, CustomerID = 1 }
        );          
        }
    }
}

