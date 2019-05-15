using Estate.Business.Contracts;
using Estate.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estate.Data.Entities;

namespace Estate.Business
{
    class CategoryFeatureEngine : BusinessEngineBase, ICategoryFeatureEngine
    {
        public void Add(CategoryFeature bus)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryFeature> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryFeature> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryFeature> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryFeature> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryFeature bus)
        {
            throw new NotImplementedException();
        }
    }
}
