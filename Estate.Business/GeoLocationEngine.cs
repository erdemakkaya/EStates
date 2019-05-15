using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estate.Data.Entities;

namespace Estate.Business
{
    public class GeoLocationEngine : BusinessEngineBase, IGeoLocationEngine
    {
        public void Add(GeoLocation bus)
        {
            throw new NotImplementedException();
        }

        public Task<GeoLocation> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GeoLocation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<GeoLocation> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<GeoLocation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(GeoLocation bus)
        {
            throw new NotImplementedException();
        }
    }
}
