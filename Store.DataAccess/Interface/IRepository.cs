using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.DataAccess.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(string[] IncludeProperties = null);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string[] IncludeProperties = null);
        TEntity FindById(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int Id);
    }
}
