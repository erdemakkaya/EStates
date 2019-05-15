using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estate.Data.Entities;

namespace Estate.Business
{
    public class FeatureEngine : BusinessEngineBase, IFeatureEngine
    {
        public void Add(Feature bus)
        {
            throw new NotImplementedException();
        }

        public Task<Feature> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Feature> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Feature> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Feature> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Feature bus)
        {
            throw new NotImplementedException();
        }
    }
}
