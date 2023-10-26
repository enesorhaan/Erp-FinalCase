using Erp.Base.Model;
using System.Linq.Expressions;

namespace Erp.Data.Repository
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes);
        T GetById(int id, params string[] includes);
        List<T> GetAll(params string[] includes);
        void Delete(int id);
        void Delete(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Update(T entity);
        void Insert(T entity);
        void InsertRange(List<T> entities);
        IQueryable<T> GetAsQueryable(params string[] includes);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression, params string[] includes);
    }
}
