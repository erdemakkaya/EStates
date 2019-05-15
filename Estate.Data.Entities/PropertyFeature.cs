using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class PropertyFeature : EntityBase<int>
    {
        public string Value { get; set; }
        public virtual ICollection<Property> Property { get; set; }
        public virtual ICollection<CategoryFeature> CategoryFeature { get; set; }

    }
}
