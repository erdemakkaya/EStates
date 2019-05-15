using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class Property : EntityBase<int>
    {
        public double Price { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public float Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool TypeOfProperty { get; set; }
        public bool IsSold { get; set; }
        public int Status { get; set; }
        public double Discount { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual GeoLocation GeoLocation { get; set; }

        public virtual ICollection<Photo> Photo { get; set; }


    }
}
