using Erp.Base.Model;
using Erp.Data.Entities;
using System.Linq.Expressions;

namespace Erp.Data.Repository
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        T GetById(int id, params string[] includes);
        List<T> GetAll(params string[] includes);
        List<Order> GetAllOrderDaily(params string[] includes);
        List<Order> GetAllOrderWeekly(params string[] includes);
        List<Order> GetAllOrderMonthly(params string[] includes);
        List<Order> GetAllOrderByDealerId(int id, params string[] includes);
        List<Order> GetAllOrderDailyByDealerId(int id, params string[] includes);
        List<Order> GetAllOrderWeeklyByDealerId(int id, params string[] includes);
        List<Order> GetAllOrderMonthlyByDealerId(int id, params string[] includes);
        List<Product> GetAllProduct(params string[] includes);
        List<Product> GetAllProductCheckStock(params string[] includes);
        void Delete(int id);
        void Delete(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Update(T entity);
        void Insert(T entity);
    }
}
