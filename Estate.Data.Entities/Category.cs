using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
   public class Category:EntityBase<int>
    {
        public string CategoryName { get; set; }
    
        public virtual ICollection<CategoryFeature> Feature { get; set; }
    }
}
