using ECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Entity
{
    public class Supplier:BaseClass
    {
        [MaxLength(255)]
        public string CompanyName { get; set; }
        [MaxLength(255)]
        public string ContactName { get; set; }
        [MaxLength(500)]
        public string Adress { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public List<Product> Products { get; set; }

    }
}
