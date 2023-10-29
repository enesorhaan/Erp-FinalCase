using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Data.Repository;
using Serilog;

namespace Erp.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext dbContext;

        public UnitOfWork(MyDbContext dbContext)
        {
            this.dbContext = dbContext;

            CompanyRepository = new GenericRepository<Company>(dbContext);    
            DealerRepository = new GenericRepository<Dealer>(dbContext);
            CurrentAccountRepository = new GenericRepository<CurrentAccount>(dbContext);
            ProductRepository = new GenericRepository<Product>(dbContext);
            OrderRepository = new GenericRepository<Order>(dbContext);
            OrderItemRepository = new GenericRepository<OrderItem>(dbContext);
            MessageRepository = new GenericRepository<Message>(dbContext);

        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public void CompleteTransaction()
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Error("CompleteTransaction", ex);
                }
            }
        }

        public IGenericRepository<Company> CompanyRepository { get; private set; }

        public IGenericRepository<Dealer> DealerRepository { get; private set; }

        public IGenericRepository<CurrentAccount> CurrentAccountRepository { get; private set; }

        public IGenericRepository<Product> ProductRepository { get; private set; }

        public IGenericRepository<Order> OrderRepository { get; private set; }

        public IGenericRepository<OrderItem> OrderItemRepository { get; private set; }

        public IGenericRepository<Message> MessageRepository { get; private set; }

    }
}
