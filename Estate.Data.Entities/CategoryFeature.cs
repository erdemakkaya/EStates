using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class CategoryFeature : EntityBase<int>
    {
       

      
        public virtual Feature Feature { get; set; }
    
        public virtual Category Category { get; set; }

    }
}
