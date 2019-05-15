using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class Photo : EntityBase<int>
    {
        public string ImageUrl { get; set; }
        public virtual Property Property { get; set; }

    }
}
