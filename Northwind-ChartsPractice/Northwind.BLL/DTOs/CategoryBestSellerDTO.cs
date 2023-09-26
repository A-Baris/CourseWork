using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class CategoryBestSellerDTO
    {
        public string CategoryName { get; set; }
       
        public int Total { get;set; }
    }
}
