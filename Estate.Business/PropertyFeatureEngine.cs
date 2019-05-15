using Estate.Business.Contracts;
using Estate.Core.Contracts;
using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Business
{
    class PropertyFeatureEngine : BusinessEngineBase, IPropertyFeatureEngine
    {
        public void Add(PropertyFeature bus)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyFeature> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyFeature> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyFeature> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyFeature> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PropertyFeature bus)
        {
            throw new NotImplementedException();
        }
    }
}
