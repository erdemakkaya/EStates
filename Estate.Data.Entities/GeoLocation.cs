using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
  public  class GeoLocation:EntityBase<int>
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public int Zoom { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        
    }
}
