using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Core.SearchModel
{
    public class PropertySearchModel
    {
        public int? Id { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int Status { get; set; }
        public int TypeOfProperty { get; set; }
        public string  City { get; set; }
        public int CategoryId { get; set; }
        public double[] ValueList { get; set; }
        public string Adress { get; set; }
    }
}
