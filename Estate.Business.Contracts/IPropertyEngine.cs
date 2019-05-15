using Estate.Core.Contracts;
using Estate.Core.SearchModel;
using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Business.Contracts
{
 public   interface IPropertyEngine: IBusinessEngine<Property>
    {

         IQueryable<Property> GetAll(PropertySearchModel model);

        Property Get(int id);


    }
}
