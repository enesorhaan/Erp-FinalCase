using Erp.Base.Model;
using Erp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Erp.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly MyDbContext dbContext;
        public GenericRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public IQueryable<T> GetAsQueryable(params string[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query;
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

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Insert(T entity)
        {
            entity.InsertDate = DateTime.UtcNow;
            entity.IsActive = true;
            dbContext.Set<T>().Add(entity);
        }

        public void InsertRange(List<T> entities)
        {
            entities.ForEach(x =>
            {
                x.InsertDate = DateTime.UtcNow;
                x.IsActive = true;
            });
            dbContext.Set<T>().AddRange(entities);
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

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();
            query.Where(expression);
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query.ToList();
        }
    }
}
