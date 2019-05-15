using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Core.Contracts
{
   public  interface IBusinessEngine<TEntity>
        where TEntity:class
    {
        Task<TEntity> Delete(int id);
        IQueryable<TEntity> GetAll();
       
        Task<TEntity> GetAsync(int id);
        void Add(TEntity bus);
        void Update(TEntity bus);
        IQueryable<TEntity> GetAll(int skip, int take);
    }
}
