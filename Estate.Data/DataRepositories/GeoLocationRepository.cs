using Estate.Data.Contacts;
using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.DataRepositories
{
   public class GeoLocationRepository:RepositoryBase<GeoLocation,int>,IGeoLocationRepository
    {
        public GeoLocationRepository(DbContext dbContext)
         : base(dbContext)
        {

        }
    }
}
