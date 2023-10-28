using Erp.Data.Entities;
using Erp.Data.Repository;

namespace Erp.Data.UoW
{
    public interface IUnitOfWork
    {
        void Complete();
        void CompleteTransaction();

        IGenericRepository<Company> CompanyRepository { get; }
        IGenericRepository<Dealer> DealerRepository { get; }
        IGenericRepository<CurrentAccount> CurrentAccountRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderItem> OrderItemRepository { get; }
        IGenericRepository<Message> MessageRepository { get; }

    }
}
