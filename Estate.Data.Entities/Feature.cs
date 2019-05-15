using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class Feature : EntityBase<int>
    {
        public string FeatureName { get; set; }
        public string Value { get; set; }
        public bool IsValid { get; set; }
        public virtual ICollection<CategoryFeature> CategoryFeature { get; set; }
    }
}
