using ECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AbstractServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetOfflineProducts();
        //List
        IEnumerable<Product> GetAllProducts();

        //Create
        string Create(Product entity);

        //Update
        string Update(Product entity);

        //Delete
        string Delete(int id);

        //Get
        Product GetbyId(int id);
    }
}
