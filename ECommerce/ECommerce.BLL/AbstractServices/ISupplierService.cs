using ECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AbstractServices
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetOfflineSuppliers();
        //List
        IEnumerable<Supplier> GetAllSuppliers();

        //Create
        string Create(Supplier entity);

        //Update
        string Update(Supplier entity);

        //Delete
        string Delete(int id);

        //Get
        Supplier GetbyId(int id);
    }
}
