using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Erp.Base.Model;
using Erp.Data.Context;
using Erp.Data.Entities;
using Dapper;


namespace Erp.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly MyDbContext dbContext;
        private readonly DapperContext dapperContext;
        public GenericRepository(MyDbContext dbContext, DapperContext dapperContext)
        {
            this.dbContext = dbContext;
            this.dapperContext = dapperContext;
        }
        public void Delete(int id)
        {
            var entity = dbContext.Set<T>().Find(id);
            entity.IsActive = false;
            entity.UpdateDate = DateTime.UtcNow;
            dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsActive = false;
            entity.UpdateDate = DateTime.UtcNow;
            dbContext.Set<T>().Update(entity);
        }

        public List<T> GetAll(params string[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query.ToList();
        }

        public List<Order> GetAllOrderDaily(params string[] includes)
        {
            var query = "SELECT * FROM Orders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderWeekly(params string[] includes)
        {
            var query = "SELECT * FROM Orders WHERE DATEPART(week, OrderDate) = DATEPART(week, GETDATE())";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderMonthly(params string[] includes)
        {
            var query = "SELECT * FROM Orders WHERE DATEPART(month, OrderDate) = DATEPART(month, GETDATE())";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderByDealerId(int id, params string[] includes)
        {
            var query = $"SELECT * FROM Orders WHERE DealerId = {id}";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderDailyByDealerId(int id, params string[] includes)
        {
            var query = $"SELECT * FROM Orders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE) AND DealerId = {id}";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderWeeklyByDealerId(int id, params string[] includes)
        {
            var query = $"SELECT * FROM Orders WHERE DATEPART(week, OrderDate) = DATEPART(week, GETDATE()) AND DealerId = {id}";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Order> GetAllOrderMonthlyByDealerId(int id, params string[] includes)
        {
            var query = $"SELECT * FROM Orders WHERE DATEPART(month, OrderDate) = DATEPART(month, GETDATE()) AND DealerId = {id}";

            using (var connection = dapperContext.CreateConnection())
            {
                var orders = connection.Query<Order>(query);
                return orders.ToList();
            }
        }

        public List<Product> GetAllProduct(params string[] includes)
        {
            var query = "SELECT ProductName, ProductStock FROM Product";

            using (var connection = dapperContext.CreateConnection())
            {
                var products = connection.Query<Product>(query);
                return products.ToList();
            }
        }

        public List<Product> GetAllProductCheckStock(params string[] includes)
        {
            var query = "SELECT ProductName, ProductStock FROM Product WHERE ProductStock < 10";

            using (var connection = dapperContext.CreateConnection())
            {
                var products = connection.Query<Product>(query);
                return products.ToList();
            }
        }

        public T GetById(int id, params string[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            entity.InsertDate = DateTime.UtcNow;
            entity.IsActive = true;
            dbContext.Set<T>().Add(entity);
        }

        public void Remove(int id)
        {
            var entity = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(entity);
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.UtcNow;
            dbContext.Set<T>().Update(entity);
        }

    }
}
