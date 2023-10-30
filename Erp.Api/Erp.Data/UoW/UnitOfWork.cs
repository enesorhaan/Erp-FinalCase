using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Data.Repository;
using Serilog;

namespace Erp.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext dbContext;
        private readonly DapperContext dapperContext;

        public UnitOfWork(MyDbContext dbContext, DapperContext dapperContext)
        {
            this.dbContext = dbContext;
            this.dapperContext = dapperContext;

            CompanyRepository = new GenericRepository<Company>(dbContext, dapperContext);    
            DealerRepository = new GenericRepository<Dealer>(dbContext, dapperContext);
            CurrentAccountRepository = new GenericRepository<CurrentAccount>(dbContext, dapperContext);
            ProductRepository = new GenericRepository<Product>(dbContext, dapperContext);
            OrderRepository = new GenericRepository<Order>(dbContext, dapperContext);
            OrderItemRepository = new GenericRepository<OrderItem>(dbContext, dapperContext);
            MessageRepository = new GenericRepository<Message>(dbContext, dapperContext);

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
