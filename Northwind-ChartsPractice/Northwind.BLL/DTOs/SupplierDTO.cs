using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class SupplierDTO
    {
        [Required(ErrorMessage ="Id boş geçilemez")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "ContactName boş geçilemez")]

        public string ContactName { get; set; }
        [Required(ErrorMessage = "Şirket adı boş geçilemez")]

        public string CompanyName { get; set; }
    }
}
