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
   public class PhotoRepository : RepositoryBase<Photo, int>, IPhotoRepository
    {
        public PhotoRepository(DbContext dbContext)
         : base(dbContext)
        {

        }
    }
}
