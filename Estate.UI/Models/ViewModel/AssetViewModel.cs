using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Estate.Data.Entities;
using System.Web.Mvc;

namespace Estate.UI.Models.ViewModel
{
    public class AssetViewModel:IDisposable
    {
    
        public Property property { get; set; }
        public IQueryable<Category> CategoryList { get; set; }
        public GeoLocation geoLocation { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}