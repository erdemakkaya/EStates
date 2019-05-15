using Estate.Data.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Estate.Data.Entities;
using System.Data.Entity;

namespace Estate.Data.DataRepositories
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>,IDisposable
        where TEntity : EntityBase<TKey>

    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public Task<TEntity> GetAsync(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll(int skip, int take)
        {
            return _dbSet.OrderBy(q => q.Id).Skip(skip).Take(take);
        }

        public IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll(skip, take).Where(predicate);
        }

        public  TEntity Add(TEntity entity)
        {
          var result=  _dbSet.Add(entity);
            SaveChanges();
            return result;
        }

        public bool Update(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Modified; //do it here

                _dbSet.Attach(entity); //attach

                _dbContext.SaveChanges(); //save it
            }
            return true;
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        public   Task SaveChangeAsync()
        {
            return   _dbContext.SaveChangesAsync();
        }



        ~RepositoryBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.OrderBy(q => q.Id).Where(predicate);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }
    }
}
