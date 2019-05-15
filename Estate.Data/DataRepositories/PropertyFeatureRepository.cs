using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.DataRepositories
{
    public class PropertyFeatureRepository:RepositoryBase<PropertyFeature,int>
    {
        public PropertyFeatureRepository(DbContext dbContext)
         : base(dbContext)
        {

        }

    }
}
