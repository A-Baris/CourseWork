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
        [MaxLength(255)]
        public string ContactTitle { get; set; }
        [MaxLength(255)]
        public string Adress { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
