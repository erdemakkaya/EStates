using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Contacts
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<TEntity> GetAsync(TKey id);
        TEntity Get(TKey id);
        IQueryable<TEntity> GetAll(int skip, int take);
        IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        Task DeleteAsync(TKey id);
        void Delete(TEntity entity);
        Task SaveChangeAsync();
        void SaveChanges();
    }
}
