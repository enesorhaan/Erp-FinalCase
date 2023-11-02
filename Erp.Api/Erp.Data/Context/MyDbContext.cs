using Erp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Erp.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        DbSet<Company> Companies { get; set; }
        DbSet<Dealer> Dealers { get; set; }
        DbSet<CurrentAccount> CurrentAccounts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DealerConfiguration());
            modelBuilder.ApplyConfiguration(new CurrentAccountConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
