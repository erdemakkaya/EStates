using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data.Entities
{
    public class User : EntityBase<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Mail { get; set; }
        public string Pw { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string UserType { get; set; }




    }
}
